using System.Collections.Generic;
using System.Threading.Tasks;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Interface;

namespace Gedjua.Runner.Game.Core
{
    public class AssetsLoader
    {
        private IAssetLoadService _loadService;
        private DataConfig _dataConfig;
        private List<Task> _tasks = new();

        public AssetsLoader(DataConfig dataConfig, IAssetLoadService loadService)
        {
            _dataConfig = dataConfig;
            _loadService = loadService;
        }

        public async Task LoadAssetsAsync()
        {
            _tasks = new List<Task>
            {
                _loadService.LoadAssetToCacheAsync(_dataConfig.PlayerAssetName),
                _loadService.LoadAssetToCacheAsync(_dataConfig.Coin1AssetName),
                _loadService.LoadAssetToCacheAsync(_dataConfig.Coin2AssetName),
                _loadService.LoadAssetToCacheAsync(_dataConfig.Ground1AssetName),
                _loadService.LoadAssetToCacheAsync(_dataConfig.Ground2AssetName),
                _loadService.LoadAssetToCacheAsync(_dataConfig.Ground3AssetName),
                _loadService.LoadAssetToCacheAsync(_dataConfig.Obstacle1AssetName),
                _loadService.LoadAssetToCacheAsync(_dataConfig.Obstacle2AssetName)
            };

            await Task.WhenAll(_tasks);
        }
    }
}
