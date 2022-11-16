using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Config;

namespace Gedjua.Runner.Game.Player.States
{
    public class PlayerStatesContainer
    {
        private JumpPlayerState _jumpPlayerState;
        private MovePlayerState _movePlayerState;

        public PlayerStatesContainer(PlayerMoveController playerMoveController,   PlayerConfig playerConfig)
        {
            _jumpPlayerState = new JumpPlayerState(playerMoveController,playerConfig);
            _movePlayerState = new MovePlayerState(playerMoveController,playerConfig);
        }

        public PlayerState GetStateByType(PlayerStateType stateType)
        {
            switch (stateType)
            {
                case PlayerStateType.Move:
                    return _movePlayerState;
                case PlayerStateType.Jump:
                    return _jumpPlayerState;
                case PlayerStateType.None:
                    return null;
                default:
                    return null;
            }
        }
    }
}