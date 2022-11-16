using System;
using System.Collections.Generic;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Interface;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Gedjua.Runner.Game.Core
{
    public class AssetsManager : IDisposable
    {
        private DataConfig _dataConfig;
        private IAssetLoadService _loadService;
        
        private readonly List<AsyncOperationHandle<GameObject>> _assetHandles = new();
        private readonly List<GameObject> _coins = new();
        private readonly List<GameObject> _tails = new();
        private readonly List<GameObject> _obstacles = new();

        [Inject]
        public void Constructor(DataConfig dataConfig, IAssetLoadService loadService)
        {
            _dataConfig = dataConfig;
            _loadService = loadService;
        }

        public GameObject GetHero()
        {
            var playerHandle = _loadService.LoadAssetAsync(_dataConfig.PlayerAssetName);
           
            _assetHandles.Add(playerHandle);
            return playerHandle.Result;
        } 
        
        public List<GameObject> GetCoins()
        {
            var coin1 = _loadService.LoadAssetAsync(_dataConfig.Coin1AssetName);
            var coin2 =  _loadService.LoadAssetAsync(_dataConfig.Coin2AssetName);
           
            _assetHandles.AddRange(new [] { coin1, coin2 });
            _coins.AddRange(new [] { coin1.Result, coin2.Result });
            return _coins;
        }
        
        public List<GameObject> GetObstacles()
        {
            var obst1 = _loadService.LoadAssetAsync(_dataConfig.Obstacle1AssetName);
            var obst2 = _loadService.LoadAssetAsync(_dataConfig.Obstacle2AssetName);
          
            _assetHandles.AddRange(new [] { obst1, obst2 });
            _obstacles.AddRange(new [] { obst1.Result, obst2.Result });
            return _obstacles;
        }
        
        public List<GameObject> GetTails()
        {
            var tail1 = _loadService.LoadAssetAsync(_dataConfig.Ground1AssetName);
            var tail2 = _loadService.LoadAssetAsync(_dataConfig.Ground2AssetName);
            var tail3 = _loadService.LoadAssetAsync(_dataConfig.Ground3AssetName);
            
            _assetHandles.AddRange(new [] { tail1, tail2, tail3 });
            _tails.AddRange(new [] { tail1.Result, tail2.Result, tail3.Result });
            return _tails;
        }

        public void Dispose()
        {
            foreach (var handle in _assetHandles)
            {
                _loadService.UnloadAsset(handle);
            }
        }
    }
}
