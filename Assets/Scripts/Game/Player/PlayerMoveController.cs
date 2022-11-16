using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Game.Player.States;
using Gedjua.Runner.Game.Road;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveController : MonoBehaviour
    {
        private PlayerStatesContainer _playerStatesContainer;
        private CollisionDetector _collisionDetector;
        private PlayerState _playerStateCurrent;
        private TileSpeedBoost _tileSpeedBoost;
        private PlayerConfig _settings;

        private Vector3 _playerPosition;
        private Rigidbody _rb;

        public PlayerStateType PlayerStateType { get; set;}
        public SwipeDirectionType CurrentDirection { get; set;}

        public int CurrentPos { get; set;}

        [Inject]
        private void Construct (PlayerConfig config, TileSpeedBoost tileSpeedBoost)
        {
            _settings = config;
            _tileSpeedBoost = tileSpeedBoost;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            CurrentPos = 1;
            InitStates();
        }

        private void Update()
        {
            _playerPosition = transform.position;
            _playerStateCurrent?.Execute(_rb, _playerPosition);
        }

        public void MoveLeft()
        {
            CurrentPos--;
        }
        
        public void MoveRight()
        {
            CurrentPos++;
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, 1f);
        }

        public void ActiveState(PlayerStateType state)
        {
            _playerStateCurrent = _playerStatesContainer.GetStateByType(state);
        }
        
        public void Boost()
        { 
            _tileSpeedBoost.Activate();
        }
        
        private void InitStates()
        {
            _playerStatesContainer = new PlayerStatesContainer(this, _settings);
        }
    }
}