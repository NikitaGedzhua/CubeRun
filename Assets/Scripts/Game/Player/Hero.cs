using System;
using Gedjua.Runner.Game.Road;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Player
{
    public class Hero : MonoBehaviour
    {
        private TileSpeedBoost _tileSpeedBoost;
        private bool _isAlive = true;
        
        public event Action BoostedHitObstacle;
        public event Action HeroIsDead;
        
        public bool IsAlive => _isAlive;

        [Inject]
        private void Construct (TileSpeedBoost speedBoost)
        {
            _tileSpeedBoost = speedBoost;
        }

        public void ObstacleHit()
        {
            if (_tileSpeedBoost.IsBoosted)
            {
                BoostedHitObstacle?.Invoke();
                return;
            }
            _isAlive = false;
            HeroIsDead?.Invoke();
        }
    }
}