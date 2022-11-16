using System;
using System.Collections.Generic;
using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Game.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gedjua.Runner.Game.Road
{
    public class CoinGenerator : Spawner, ITickable, IInitializable , IDisposable
    {
        private readonly Coin.Factory _coinFactory;
        private readonly RoadObjConfig _config;
        private readonly CollisionDetector _collisionDetector;
        private float _xOffset;

        public CoinGenerator(Coin.Factory coinFactory, CollisionDetector collisionDetector, RoadObjConfig roadObjConfig)
        {
            _coinFactory = coinFactory;
            _config = roadObjConfig;
            _collisionDetector = collisionDetector;
            _collisionDetector.CollidedObject += ReplaceCollidedCoin;
        }
        
        public void Initialize()
        {
            PosGenerator = new RoadObjPositionGenerator();
            _spawnedObjects = new List<GameObject>();
            _distBetweenObj = _config.DistanceBetweenCoins;;
            _startObjectCount = _config.StartCoinsCount;
            _spawnPos = _config.CoinsSpawnPos;
            _deadZone = _config.CoinsDeadZone;
            _leftPosLimit = _config._leftPosLimitCoin;
            _rightPosLimit = _config._rightPosLimitCoin;
            
            for (int i = 0; i < _startObjectCount; i++)
            {
                var coin = _coinFactory.Create().gameObject;
                coin.transform.position = PosGenerator.GeneratePosition(_spawnPos);
                _spawnedObjects.Add(coin);
                _spawnPos += _distBetweenObj;
            }
        }
        
        public void Dispose()
        {
            _collisionDetector.CollidedObject -= ReplaceCollidedCoin;
        }

        public void Tick()
        {
            ReplaceCoins();
        }

        private void ReplaceCoins()
        {
            foreach (var coin in _spawnedObjects)
            {
                if (coin.transform.position.z < _deadZone)
                {
                    SetNewCoinPos(coin);
                }
            }
        }

        private void SetNewCoinPos(GameObject obj)
        {
            var newCoinPos = obj.transform.position;
            _xOffset = Random.value > 0.5f ? _rightPosLimit : _leftPosLimit;
            newCoinPos = new Vector3(_xOffset, newCoinPos.y, newCoinPos.z + _distBetweenObj * _startObjectCount);
            obj.transform.position = newCoinPos;
        }

        private void ReplaceCollidedCoin(RoadObject roadObject)
        {
            if (roadObject.RoadObjects == RoadObjects.Coin)
            {
                SetNewCoinPos(roadObject.gameObject);
            }
        }
    }
}

