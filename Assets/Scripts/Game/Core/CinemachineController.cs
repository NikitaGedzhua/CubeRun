using System;
using System.Threading.Tasks;
using Cinemachine;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Game.Player;
using Gedjua.Runner.Game.Road;
using UnityEngine;
using Zenject;

public class CinemachineController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCameraMain;
    [SerializeField] private CinemachineVirtualCamera _virtualCameraDeath;

    private Hero _hero;
    private CameraConfig _cameraConfig;
    private TileSpeedBoost _tileSpeedBoost;
    private CinemachineBasicMultiChannelPerlin _basicMultiChannel;
    private CinemachineTransposer _cinemachineTransposer;
    private Transform _playerPosition;
   
    private float _startFOV;
    private float _startCameraOffsetY;
    private float _currentVelocityIncreaseFOV;
    private float _currentVelocityIncreaseOffset;
    private float _currentVelocityDecreaseFOV;
    private float _currentVelocityDecreaseOffset;
    
    [Inject]
    public void Constructor(CameraConfig cameraConfig, TileSpeedBoost tileSpeedBoost, Hero hero)
    {
        _hero = hero;
        _cameraConfig = cameraConfig;
        _tileSpeedBoost = tileSpeedBoost;
    }

    private void Awake()
    {
        _hero.BoostedHitObstacle += ShakeCamera;
        _hero.HeroIsDead += SelectDeathCamera;
    }

    private void OnDisable()
    {
        _hero.BoostedHitObstacle -= ShakeCamera;
        _hero.HeroIsDead -= SelectDeathCamera;
    }

    private void Start()
    {
        InitFields();
        SetCamerasTarget(_virtualCameraMain);
        SetCamerasTarget(_virtualCameraDeath);
    }

    private void Update()
    {
        ChangeCameraView();
    }

    private void InitFields()
    {
        _playerPosition = _hero.gameObject.transform;
        _basicMultiChannel = _virtualCameraMain.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cinemachineTransposer = _virtualCameraMain.GetCinemachineComponent<CinemachineTransposer>();
        _startFOV = _virtualCameraMain.m_Lens.FieldOfView;
        _startCameraOffsetY = _cinemachineTransposer.m_FollowOffset.y;
    }

    private void SetCamerasTarget(CinemachineVirtualCamera cam)
    {
        cam.LookAt = _playerPosition;
        cam.Follow = _playerPosition;
    }

    private async void ShakeCamera()
    {
        _basicMultiChannel.m_AmplitudeGain = _cameraConfig.CameraShakeIntensity;
        
        await Task.Delay(TimeSpan.FromSeconds(_cameraConfig.CameraShakeTime));
        _basicMultiChannel.m_AmplitudeGain = 0;
    }
    
    private void ChangeCameraView()
    {
        if (!_hero.IsAlive) return;
        if (_tileSpeedBoost.IsBoosted)
        {
            ChangeFOV(_cameraConfig.CameraBoostFOV,_currentVelocityIncreaseFOV, _cameraConfig.CameraChangeViewTime); 
            ChangeOffset(_cameraConfig.CameraBoostOffsetY, _currentVelocityIncreaseOffset, _cameraConfig.CameraChangeViewTime);
        }
        else
        {
            ChangeFOV(_startFOV,_currentVelocityDecreaseFOV, _cameraConfig.CameraChangeViewTime);
            ChangeOffset(_startCameraOffsetY, _currentVelocityDecreaseOffset, _cameraConfig.CameraChangeViewTime);
        }
    }

    private void ChangeFOV(float target, float velocityChange, float changeTime)
    {
        var currentFOV = _virtualCameraMain.m_Lens.FieldOfView;
        currentFOV = Mathf.SmoothDamp(currentFOV, target, ref velocityChange, changeTime);
        _virtualCameraMain.m_Lens.FieldOfView = currentFOV;
    }

    private void ChangeOffset(float target, float velocityChange, float changeTime)
    {
        var currentOffsetY = _cinemachineTransposer.m_FollowOffset.y;
        currentOffsetY = Mathf.SmoothDamp(currentOffsetY, target, ref velocityChange, changeTime);
        _cinemachineTransposer.m_FollowOffset.y = currentOffsetY;
    }

    private void SelectDeathCamera()
    {
        _virtualCameraDeath.Priority = _virtualCameraMain.Priority + 1;
    }
}