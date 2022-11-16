using Gedjua.Runner.Interface;
using UnityEngine;

namespace Gedjua.Runner.Game.Road
{
    public class RoadObjPositionGenerator :  IPositionGenerator
    {
        private Vector3 _targetPos;
        private float _xOffset;
        private float _yOffset = 0.5f;
        private float _leftPosLimit = -3f;
        private float _rightPosLimit = 3f;

        public Vector3 GeneratePosition(float spawnPos)
        {
            _xOffset = Random.value > 0.5f ? _rightPosLimit : _leftPosLimit; 
            var newPosition = new Vector3(_targetPos.x + _xOffset, _targetPos.y + _yOffset, spawnPos); 
            return newPosition;
        }
    }
}

