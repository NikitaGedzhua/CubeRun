using System.Collections.Generic;
using Gedjua.Runner.Game.Core;
using Gedjua.Runner.Game.Road;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gedjua.Runner.Installers
{
    public class RoadObjectInstaller : MonoInstaller
    { 
        private AssetsManager _assetsManager;

        private List<GameObject> _coins = new();
        private List<GameObject> _tails = new();
        private List<GameObject> _obstacles = new();
        
        [Inject]
        public void Constructor(AssetsManager assetsManager)
        {
            _assetsManager = assetsManager;
        }
       
        public override void InstallBindings()
        {
            AddAssetsToLists();
            InstallTail();
            InstallCoins();
            InstallObstacle();
        }

        private void InstallCoins()
        {
            Container.BindInterfacesTo<CoinGenerator>().AsSingle();
            Container.BindFactory<Coin, Coin.Factory>().FromMethod(SpawnCoin);
        }
        
        private void InstallObstacle()
        {
            Container.BindInterfacesTo<ObstacleGenerator>().AsSingle();
            Container.BindFactory<Obstacle, Obstacle.Factory>().FromMethod(SpawnObstacle);
        }
        
        private void InstallTail()
        {
            Container.BindInterfacesTo<TileGenerator>().AsSingle();
            Container.BindFactory<Tile, Tile.Factory>().FromMethod(SpawnTail);
        }

        private void AddAssetsToLists()
        {
            _coins = _assetsManager.GetCoins();
            _obstacles = _assetsManager.GetObstacles();
            _tails = _assetsManager.GetTails();
        }

        private Coin SpawnCoin(DiContainer di)
        {
            var coin = _coins[Random.Range(0, _coins.Count)];
            return Container.InstantiatePrefabForComponent<Coin>(coin);
        }
        
        private Obstacle SpawnObstacle(DiContainer di)
        {
            var obstacle = _obstacles[Random.Range(0, _obstacles.Count)];
            return Container.InstantiatePrefabForComponent<Obstacle>(obstacle);
        }
        
        private Tile SpawnTail(DiContainer di)
        {
            var tail = _tails[Random.Range(0, _tails.Count)];
            return Container.InstantiatePrefabForComponent<Tile>(tail);
        }
    }
}