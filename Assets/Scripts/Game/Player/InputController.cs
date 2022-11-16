using System;
using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Config;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gedjua.Runner.Game.Player
{
    public class InputController : IInitializable, IDisposable, ILateTickable
    {
        private readonly PlayerMoveController _playerMoveController;
        private readonly GameConfig _gameConfig;
        private PlayerInputActions _inputActions;
        private SwipeDirectionType _swipeDirections;

        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private float _startTime;
        private float _endTime;
        private float _lastClickTime;
        
        public InputController(PlayerMoveController playerMoveController, GameConfig gameConfig)
        {
            _playerMoveController = playerMoveController;
            _gameConfig = gameConfig;
        }
        
        public void Initialize()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.Player.Enable();
            
            _inputActions.Player.PrimaryContact.started += StartTouchPrimary;
            _inputActions.Player.PrimaryContact.canceled += EndTouchPrimary;
            _inputActions.Player.DoubleClick.performed += Boost;
        }
        
        public void Dispose()
        {
            _inputActions.Player.Disable();
        }
        
        public void LateTick()
        {
            _playerMoveController.CurrentDirection = SwipeDirectionType.None;
        }

        private void DetectSwipe()
        {
            if (Vector3.Distance(_startPosition,_endPosition) >= _gameConfig.SwipeMinDistance 
                && _endTime - _startTime <= _gameConfig.SwipeMaxTime)
            {
                Vector3 direction = _endPosition - _startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SetDirection(direction2D);
            }
        }
        
        private void StartTouchPrimary(InputAction.CallbackContext context)
        {
            _startPosition = _inputActions.Player.PrimaryPosition.ReadValue<Vector2>();
            _startTime = (float) context.startTime;
        }
        
        private void EndTouchPrimary(InputAction.CallbackContext context)
        {
            _endPosition = _inputActions.Player.PrimaryPosition.ReadValue<Vector2>();
            _endTime = (float) context.time;
            DetectSwipe();
        }
        
        private void SetDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up, direction) > _gameConfig.SwipeDirectionThreshold)
                _playerMoveController.CurrentDirection = SwipeDirectionType.Up;
            
            if (Vector2.Dot(Vector2.down, direction) > _gameConfig.SwipeDirectionThreshold)
                _playerMoveController.CurrentDirection = SwipeDirectionType.Down;
            
            if (Vector2.Dot(Vector2.left, direction) > _gameConfig.SwipeDirectionThreshold)
                _playerMoveController.CurrentDirection = SwipeDirectionType.Left;
            
            if (Vector2.Dot(Vector2.right, direction) > _gameConfig.SwipeDirectionThreshold)
                _playerMoveController.CurrentDirection = SwipeDirectionType.Right;
        }

        private void Boost(InputAction.CallbackContext context)
        {
            _playerMoveController.Boost();
        }
    }
}