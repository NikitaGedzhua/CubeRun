using System.IO;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Interface;
using UnityEngine;

namespace Gedjua.Runner.Game.Data
{
    public class LocalDataSaver : IDataProviderService
    {
        private readonly DataConfig _dataConfig;
        
        public LocalDataSaver(DataConfig dataConfig)
        {
            _dataConfig = dataConfig;
        }
        
        public void SaveData(float coins, float distance,string name)
        {
            var playerData = new MatchData() {LastCoins = coins, LastDistance = distance, LastPlayerName = name};
            var dataToJson = JsonUtility.ToJson(playerData);
            File.WriteAllText(Application.persistentDataPath + _dataConfig.JsonFilePath, dataToJson);
        }
    }
}