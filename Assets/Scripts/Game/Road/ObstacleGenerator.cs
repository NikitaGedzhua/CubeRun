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
    public class ObstacleGenerator : Spawner, ITickable, IInitializable, IDisposable
    {
        private readonly Obstacle.Factory _obstacleFactory;
        private readonly RoadObjConfig _config;
        private readonly CollisionDetector _collisionDetector;
       
        public ObstacleGenerator(Obstacle.Factory obstacleFactory, RoadObjConfig roadObjConfig, CollisionDetector collisionDetector)
        {
            _config = roadObjConfig;
            _obstacleFactory = obstacleFactory;
            _collisionDetector = collisionDetector;
            _collisionDetector.CollidedObject += ReplaceCollidedObstacle;
        }
        
        public void Initialize()
        {
            PosGenerator = new RoadObjPositionGenerator();
            _spawnedObjects = new List<GameObject>();
            _distBetweenObj = _config.DistanceBetweenObstacles;
            _startObjectCount = _config.StartObstaclesCount;
            _spawnPos = _config.ObstaclesSpawnPos;
            _deadZone = _config.ObstaclesDeadZone;
            _leftPosLimit = _config._leftPosLimitObst;
            _rightPosLimit = _config._rightPosLimitObst;
            
            for (int i = 0; i < _startObjectCount; i++)
            {
                var obstacle = _obstacleFactory.Create().gameObject;
                obstacle.transform.position = PosGenerator.GeneratePosition(_spawnPos);
                _spawnedObjects.Add(obstacle);
                _spawnPos += _distBetweenObj;
            }
        }
        
        public void Dispose()
        {
            _collisionDetector.CollidedObject -= ReplaceCollidedObstacle;
        }

        public void Tick()
        {
            ReplaceObstacles();
        }

        private void ReplaceObstacles()
        {
            foreach (var obstacle in _spawnedObjects)
            {
                if (obstacle.transform.position.z < _deadZone)
                {
                    SetNewObstaclePos(obstacle);
                }
            }
        }

        private void SetNewObstaclePos(GameObject obj)
        {
            var newRoadPos = obj.transform.position;
            newRoadPos = new Vector3(Random.Range(_leftPosLimit,_rightPosLimit), newRoadPos.y, newRoadPos.z + _distBetweenObj * _startObjectCount);
            obj.transform.position = newRoadPos;
        }
        
        private void ReplaceCollidedObstacle(RoadObject roadObject)
        {
            if (roadObject.RoadObjects == RoadObjects.Obstacle)
            {
                SetNewObstaclePos(roadObject.gameObject);
            }
        }
    }
}
