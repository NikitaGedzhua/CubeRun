using Gedjua.Runner.Game.Config;
using UnityEngine;

namespace Gedjua.Runner.Game.Player.States
{
    public class MovePlayerState : PlayerState
    {
        public MovePlayerState(PlayerMoveController playerMoveController,   PlayerConfig playerConfig) : 
            base(playerMoveController,  playerConfig) { }

        public override void Execute(Rigidbody rb, Vector3 pos)
        {
            _playerMoveController.CurrentPos = Mathf.Clamp(_playerMoveController.CurrentPos, 0, 2);
            var targetPos = pos;
            targetPos.x = _playerConfig.Positions[_playerMoveController.CurrentPos];
            
            rb.MovePosition(Vector3.MoveTowards(pos, targetPos, Time.fixedDeltaTime * _playerConfig.SidewaysSpeed));
        }
    }
}