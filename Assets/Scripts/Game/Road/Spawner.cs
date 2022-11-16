using System.Collections.Generic;
using Gedjua.Runner.Interface;
using UnityEngine;

namespace Gedjua.Runner.Game.Road
{
    public abstract class Spawner 
    {
        protected float _spawnPos;
        protected int _startObjectCount;
        protected float _distBetweenObj;
        protected float _deadZone;
        protected float _leftPosLimit;
        protected float _rightPosLimit;

        protected List<GameObject> _spawnedObjects;
        protected IPositionGenerator PosGenerator;
    }
}

