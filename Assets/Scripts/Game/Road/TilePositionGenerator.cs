using Gedjua.Runner.Interface;
using UnityEngine;

namespace Gedjua.Runner.Game.Road
{
    public class TilePositionGenerator :  IPositionGenerator
    {
        private Vector3 _targetPos;

        public Vector3 GeneratePosition(float spawnPos)
        {
            var newPosition = new Vector3(_targetPos.x, _targetPos.y, spawnPos); 
            return newPosition;
        }
    }
}
