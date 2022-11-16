using System;
using Gedjua.Runner.Game.Core;

namespace Gedjua.Runner.Game.Data
{
    public class MatchDataSetter : IDisposable
    {
        private MatchData _matchData;
        private ScoreDistance _scoreDistance;
        private ScoreCoins _scoreCoins;

        public MatchDataSetter( ScoreDistance scoreDistance, ScoreCoins scoreCoins, MatchData matchData)
        {
            _scoreDistance = scoreDistance;
            _scoreCoins = scoreCoins;
            _matchData = matchData;
            
            _scoreDistance.AddedDistanceScore += SetDistanceScore;
            _scoreCoins.AddedCoinScore += SetCoinsScore;
        }
        
        public void Dispose()
        {
            _scoreDistance.AddedDistanceScore -= SetDistanceScore;
            _scoreCoins.AddedCoinScore -= SetCoinsScore;
            _matchData.Distance = 0;
            _matchData.Coins = 0;
        }
        
        private void SetDistanceScore(float score)
        { 
            _matchData.Distance = score;
        }

        private void SetCoinsScore(float score)
        { 
            _matchData.Coins = score;
        }
    }
}