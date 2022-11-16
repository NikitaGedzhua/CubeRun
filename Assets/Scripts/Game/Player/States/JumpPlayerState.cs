using Gedjua.Runner.Game.Config;
using UnityEngine;

namespace Gedjua.Runner.Game.Player.States
{
    public class JumpPlayerState : PlayerState
    {
        public JumpPlayerState(PlayerMoveController playerMoveController, PlayerConfig playerConfig) : 
            base(playerMoveController, playerConfig) { }
       
        public override void Execute(Rigidbody rb, Vector3 pos)
        {
            rb.AddForce(Vector3.up * _playerConfig.JumpForce, ForceMode.VelocityChange);
        }
    }
}