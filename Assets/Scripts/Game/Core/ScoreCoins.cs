using System;
using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Player;
using Gedjua.Runner.Game.Road;

namespace Gedjua.Runner.Game.Core
{
    public class ScoreCoins : IDisposable
    {
        private readonly CollisionDetector _collisionDetector;
        private float _score;

        public event Action<float> AddedCoinScore;

        public ScoreCoins(CollisionDetector collisionDetector)
        {
            _collisionDetector = collisionDetector;
            _collisionDetector.CollidedObject += AddCoin;
        }

        public void Dispose()
        {
            _collisionDetector.CollidedObject -= AddCoin;
        }

        private void AddCoin(RoadObject roadObject)
        {
            if (roadObject.RoadObjects == RoadObjects.Coin)
            {
                var coin = roadObject.GetComponent<Coin>();
                _score += coin.CoinValue;
                AddedCoinScore?.Invoke(_score);
            }
        }
    }
}