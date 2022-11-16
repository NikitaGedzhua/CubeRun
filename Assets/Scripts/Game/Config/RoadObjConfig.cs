using System;
using UnityEngine;

namespace Gedjua.Runner.Game.Config
{
    [Serializable]
    public class RoadObjConfig
    {
        [Header("Tile Config")]
        public int StartTilesCount;
        public float TilesSpawnPos;
        public float DistanceBetweenTiles;
        public float TilesDeadZone;
        
        [Header("Obstacle Config")]
        public int StartObstaclesCount;
        public float ObstaclesSpawnPos;
        public float DistanceBetweenObstacles;
        public float ObstaclesDeadZone;
        public float _leftPosLimitObst;
        public float _rightPosLimitObst;

        
        [Header("Coin Config")]
        public int StartCoinsCount;
        public float CoinsSpawnPos;
        public float DistanceBetweenCoins;
        public float CoinsDeadZone;
        public float _leftPosLimitCoin;
        public float _rightPosLimitCoin;
    }
}
