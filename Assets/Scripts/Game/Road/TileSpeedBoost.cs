using System;
using System.Threading.Tasks;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Interface;
using Zenject;

namespace Gedjua.Runner.Game.Road
{
    public class TileSpeedBoost : IInitializable, IBoost
    {
        private readonly GameConfig _settings;
        private float _startSpeed;
        private float _startDistanceSpeed;
        private bool _isBoosted;

        public bool IsBoosted => _isBoosted;
        
        public TileSpeedBoost(GameConfig config)
        {
            _settings = config;
        }
        
        public void Initialize()
        {
            _startSpeed = _settings.TileSpeed;
            _startDistanceSpeed = _settings.DistanceSpeed;
        }

        public async void Activate()
        {
            if (_isBoosted) return;
            _isBoosted = true;
            _settings.TileSpeed = _settings.BoostSpeed;
            _settings.DistanceSpeed = _settings.BoostDistance;
           
            await Task.Delay(TimeSpan.FromSeconds(_settings.BoostTime));
            _settings.TileSpeed = _startSpeed;
            _settings.DistanceSpeed = _startDistanceSpeed;
            _isBoosted = false;
        }
    }
}