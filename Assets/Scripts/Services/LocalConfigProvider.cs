using System.Threading.Tasks;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Interface;
using UnityEngine;

namespace Gedjua.Runner.Services
{
    public class LocalConfigProvider : IConfigService
    {
        private const string DataConfigPath = "Configs/DataConfig";
        private const string GameConfigPath = "Configs/GameConfig";
        private const string PlayerConfigPath = "Configs/PlayerConfig";
        private const string RoadObjConfigPath = "Configs/RoadObjConfig";
        private const string CameraConfigPath = "Configs/CameraConfig";
        
        public async Task<DataConfig> GetDataConfigAsync()
        {
            TextAsset file = Resources.Load(DataConfigPath) as TextAsset;
            DataConfig config = JsonUtility.FromJson<DataConfig>(file.text);
            return await Task.FromResult(config);
        }

        public async Task<GameConfig> GetGameConfigAsync()
        {
            TextAsset file = Resources.Load(GameConfigPath) as TextAsset;
            GameConfig config = JsonUtility.FromJson<GameConfig>(file.text);
            return await Task.FromResult(config);
        }

        public async Task<PlayerConfig> GetPlayerConfigAsync()
        {
            TextAsset file = Resources.Load(PlayerConfigPath) as TextAsset;
            PlayerConfig config = JsonUtility.FromJson<PlayerConfig>(file.text);
            return await Task.FromResult(config);
        }

        public async Task<RoadObjConfig> GetRoadObjConfigAsync()
        {
            TextAsset file = Resources.Load(RoadObjConfigPath) as TextAsset;
            RoadObjConfig config = JsonUtility.FromJson<RoadObjConfig>(file.text);
            return await Task.FromResult(config);
        }
        
        public async Task<CameraConfig> GetCameraConfigAsync()
        {
            TextAsset file = Resources.Load(CameraConfigPath) as TextAsset;
            CameraConfig config = JsonUtility.FromJson<CameraConfig>(file.text);
            return await Task.FromResult(config);
        }
    }
}
