using Gedjua.Runner.Game.Config;
using UnityEngine;

namespace Gedjua.Runner.Game.Player.States
{
    public abstract class PlayerState
    {
        protected readonly PlayerMoveController _playerMoveController;
        protected readonly PlayerConfig _playerConfig;

        protected PlayerState(PlayerMoveController playerMoveController, PlayerConfig playerConfig)
        {
            _playerMoveController = playerMoveController;
            _playerConfig = playerConfig;
        }

        public abstract void Execute(Rigidbody rb, Vector3 position);
    }
}