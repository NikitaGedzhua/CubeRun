using Gedjua.Runner.Game.Config;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Road
{
    public class Coin : MonoBehaviour
    {
        private GameConfig _settings;
        public int CoinValue => _settings.CoinValue;

        [Inject]
        private void Construct (GameConfig config)
        {
            _settings = config;
        }
        
        public class Factory : PlaceholderFactory<Coin> {}
    }
}

