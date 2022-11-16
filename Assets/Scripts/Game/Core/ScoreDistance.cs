using System;
using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Config;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Core
{
    public class ScoreDistance :  ITickable
    {
        private GameStateManager _gameStateManager;
        private GameConfig _settings;
        private float _score;

        public event Action<float> AddedDistanceScore;

        public ScoreDistance(GameStateManager gameStateManager, GameConfig config)
        {
            _gameStateManager = gameStateManager;
            _settings = config;
        }
        
        public void Tick()
        {
            AddScore();
        }

        private void AddScore()
        {
            if (_gameStateManager.CurrentGameState == GameState.Play)
            {
                _score += _settings.DistanceSpeed * Time.deltaTime;
                AddedDistanceScore?.Invoke(_score);
            }
        }
    }
}

