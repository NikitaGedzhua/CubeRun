using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Interface;

namespace Gedjua.Runner.Game.Core
{
    public class GameConfigSetter
    {
        private IConfigService _configService;
        private DataConfig _dataConfig;
        private GameConfig _gameConfig;
        private PlayerConfig _playerConfig;
        private RoadObjConfig _roadObjConfig;
        private CameraConfig _cameraConfig;
        
        public GameConfigSetter(IConfigService remoteConfigService, DataConfig dataConfig,
            GameConfig gameConfig, PlayerConfig playerConfig, RoadObjConfig roadObjConfig, CameraConfig cameraConfig)
        {
            _configService = remoteConfigService;
            _dataConfig = dataConfig;
            _gameConfig = gameConfig;
            _playerConfig = playerConfig;
            _roadObjConfig = roadObjConfig;
            _cameraConfig = cameraConfig;
        }
        
        public void SetConfigs()
        {
            SetDataConfig();
            SetGameConfig();
            SetPlayerConfig();
            SetRoadObjConfig();
            SetCameraConfig();
        }
        
        private void SetDataConfig()
        {
            _dataConfig.JsonFilePath = _configService.GetDataConfigAsync().Result.JsonFilePath;
            _dataConfig.PlayerAssetName = _configService.GetDataConfigAsync().Result.PlayerAssetName;
            _dataConfig.Coin1AssetName = _configService.GetDataConfigAsync().Result.Coin1AssetName;
            _dataConfig.Coin2AssetName = _configService.GetDataConfigAsync().Result.Coin2AssetName;
            _dataConfig.Ground1AssetName = _configService.GetDataConfigAsync().Result.Ground1AssetName;
            _dataConfig.Ground2AssetName = _configService.GetDataConfigAsync().Result.Ground2AssetName;
            _dataConfig.Ground3AssetName = _configService.GetDataConfigAsync().Result.Ground3AssetName;
            _dataConfig.Obstacle1AssetName = _configService.GetDataConfigAsync().Result.Obstacle1AssetName;
            _dataConfig.Obstacle2AssetName = _configService.GetDataConfigAsync().Result.Obstacle2AssetName;
        } 
        
        private void SetGameConfig()
        {
            _gameConfig.CoinValue = _configService.GetGameConfigAsync().Result.CoinValue;
            _gameConfig.DistanceSpeed = _configService.GetGameConfigAsync().Result.DistanceSpeed;
            _gameConfig.TileSpeed = _configService.GetGameConfigAsync().Result.TileSpeed;
            _gameConfig.BoostSpeed = _configService.GetGameConfigAsync().Result.BoostSpeed;
            _gameConfig.BoostDistance = _configService.GetGameConfigAsync().Result.BoostDistance;
            _gameConfig.BoostTime = _configService.GetGameConfigAsync().Result.BoostTime;
            _gameConfig.DoubleClickTime = _configService.GetGameConfigAsync().Result.DoubleClickTime;
            _gameConfig.SwipeDirectionThreshold = _configService.GetGameConfigAsync().Result.SwipeDirectionThreshold;
            _gameConfig.SwipeMaxTime = _configService.GetGameConfigAsync().Result.SwipeMaxTime;
            _gameConfig.SwipeMinDistance = _configService.GetGameConfigAsync().Result.SwipeMinDistance;
        }

        private void SetPlayerConfig()
        {
            _playerConfig.Positions = _configService.GetPlayerConfigAsync().Result.Positions;
            _playerConfig.SidewaysSpeed = _configService.GetPlayerConfigAsync().Result.SidewaysSpeed;
            _playerConfig.JumpForce = _configService.GetPlayerConfigAsync().Result.JumpForce;
        } 
        
        private void SetRoadObjConfig()
        {
            _roadObjConfig.StartCoinsCount = _configService.GetRoadObjConfigAsync().Result.StartCoinsCount;
            _roadObjConfig.CoinsSpawnPos = _configService.GetRoadObjConfigAsync().Result.CoinsSpawnPos;
            _roadObjConfig.DistanceBetweenCoins = _configService.GetRoadObjConfigAsync().Result.DistanceBetweenCoins;
            _roadObjConfig.CoinsDeadZone = _configService.GetRoadObjConfigAsync().Result.CoinsDeadZone;
            _roadObjConfig._leftPosLimitCoin = _configService.GetRoadObjConfigAsync().Result._leftPosLimitCoin;
            _roadObjConfig._rightPosLimitCoin = _configService.GetRoadObjConfigAsync().Result._rightPosLimitCoin;
            
            _roadObjConfig.StartObstaclesCount = _configService.GetRoadObjConfigAsync().Result.StartObstaclesCount;
            _roadObjConfig.ObstaclesSpawnPos = _configService.GetRoadObjConfigAsync().Result.ObstaclesSpawnPos;
            _roadObjConfig.DistanceBetweenObstacles = _configService.GetRoadObjConfigAsync().Result.DistanceBetweenObstacles;
            _roadObjConfig.ObstaclesDeadZone = _configService.GetRoadObjConfigAsync().Result.ObstaclesDeadZone;
            _roadObjConfig._leftPosLimitObst = _configService.GetRoadObjConfigAsync().Result._leftPosLimitObst;
            _roadObjConfig._rightPosLimitObst = _configService.GetRoadObjConfigAsync().Result._rightPosLimitObst;
            
            _roadObjConfig.StartTilesCount = _configService.GetRoadObjConfigAsync().Result.StartTilesCount;
            _roadObjConfig.TilesSpawnPos = _configService.GetRoadObjConfigAsync().Result.TilesSpawnPos;
            _roadObjConfig.DistanceBetweenTiles = _configService.GetRoadObjConfigAsync().Result.DistanceBetweenTiles;
            _roadObjConfig.TilesDeadZone = _configService.GetRoadObjConfigAsync().Result.TilesDeadZone;
        }

        private void SetCameraConfig()
        {
            _cameraConfig.CameraShakeIntensity = _configService.GetCameraConfigAsync().Result.CameraShakeIntensity;
            _cameraConfig.CameraShakeTime = _configService.GetCameraConfigAsync().Result.CameraShakeTime;
            _cameraConfig.CameraBoostFOV = _configService.GetCameraConfigAsync().Result.CameraBoostFOV;
            _cameraConfig.CameraBoostOffsetY = _configService.GetCameraConfigAsync().Result.CameraBoostOffsetY;
            _cameraConfig.CameraChangeViewTime = _configService.GetCameraConfigAsync().Result.CameraChangeViewTime;
        }
    }
}
