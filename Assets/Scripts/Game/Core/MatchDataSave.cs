using Gedjua.Runner.Game.Data;
using Gedjua.Runner.Interface;

namespace Gedjua.Runner.Game.Core
{
    public class MatchDataSave 
    {
        private readonly IDataProviderService _dataSaver;
        private readonly MatchData _matchData;

        public MatchDataSave(IDataProviderService dataSaver, MatchData matchData)
        {
            _dataSaver = dataSaver;
            _matchData = matchData;
        }
        
        public void SaveDataToJson()
        { 
            if (_matchData.LastCoins > _matchData.Coins && _matchData.LastDistance > _matchData.Distance) return;
            _dataSaver.SaveData(_matchData.Coins, (int) _matchData.Distance, _matchData.Name);
        }
    }
}