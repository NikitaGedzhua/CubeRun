using System.IO;
using Gedjua.Runner.Game.Config;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Data
{
    public class ReadMatchData : IInitializable
    {
        private readonly DataConfig _dataConfig;
        private MatchData _matchData;
        
        public ReadMatchData(DataConfig dataConfig, MatchData matchData)
        {
            _dataConfig = dataConfig;
            _matchData = matchData;
        }
        
        public void Initialize()
        {
            ReadData();
        }

        private void ReadData()
        {
            if (File.Exists(Application.persistentDataPath + _dataConfig.JsonFilePath))
            {
                var fileContents = File.ReadAllText(Application.persistentDataPath + _dataConfig.JsonFilePath);
                var deserializedMatchData = JsonUtility.FromJson<MatchData>(fileContents);
                _matchData.LastCoins = deserializedMatchData.LastCoins;
                _matchData.LastDistance = deserializedMatchData.LastDistance;
                _matchData.LastPlayerName = deserializedMatchData.LastPlayerName;
            }
        }
    }
}
