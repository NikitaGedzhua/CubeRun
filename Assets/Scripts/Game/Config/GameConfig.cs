using System;

namespace Gedjua.Runner.Game.Config
{
    [Serializable]
    public class GameConfig 
    {
        public int CoinValue;
        public float TileSpeed;
        public float BoostSpeed;
        public float DistanceSpeed;
        public float BoostDistance;
        public float BoostTime;
        public float DoubleClickTime;
        public float SwipeDirectionThreshold;
        public float SwipeMinDistance;
        public float SwipeMaxTime;
    }
}