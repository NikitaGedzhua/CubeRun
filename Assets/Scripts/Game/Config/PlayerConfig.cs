using System;

namespace Gedjua.Runner.Game.Config
{
    [Serializable]
    public class PlayerConfig
    {
        public float SidewaysSpeed;
        public  float[] Positions;
        public float JumpForce;
    }
}