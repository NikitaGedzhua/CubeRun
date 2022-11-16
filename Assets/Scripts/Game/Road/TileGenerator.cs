using System.Collections.Generic;
using Gedjua.Runner.Game.Config;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Road
{
    public class TileGenerator : Spawner, ITickable, IInitializable
    {
        private readonly Tile.Factory _tileFactory;
        private readonly RoadObjConfig _config;
        
        public TileGenerator(Tile.Factory tileFactory, RoadObjConfig roadObjConfig)
        {
            _tileFactory = tileFactory;
            _config = roadObjConfig;
        }
        
        public void Initialize()
        {
            PosGenerator = new TilePositionGenerator();
            _spawnedObjects = new List<GameObject>();
            _spawnPos = _config.TilesSpawnPos;
            _distBetweenObj = _config.DistanceBetweenTiles;
            _startObjectCount = _config.StartTilesCount;
            _deadZone = _config.TilesDeadZone;

            for (int i = 0; i < _startObjectCount; i++)
            {
                var tile = _tileFactory.Create().gameObject;
                tile.transform.position = PosGenerator.GeneratePosition(_spawnPos);
                _spawnedObjects.Add(tile);
                _spawnPos += _distBetweenObj;
            }
        }
       
        public void Tick()
        {
            ReplaceTiles(_spawnedObjects);
        }

        private void ReplaceTiles(List<GameObject> activeGameObj)
        {
            foreach (var tile in activeGameObj)
            {
                if (tile.transform.position.z < _deadZone)
                {
                    var newRoadPos = tile.transform.position;
                    newRoadPos = new Vector3(newRoadPos.x, newRoadPos.y, newRoadPos.z + _distBetweenObj * _startObjectCount);
                    tile.transform.position = newRoadPos;
                }
            }
        }
    }
}
