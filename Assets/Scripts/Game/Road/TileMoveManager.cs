using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Config;
using Gedjua.Runner.Game.Core;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Road
{ 
    public class TileMoveManager : MonoBehaviour 
    { 
        private GameConfig _settings;
        private GameStateManager _gameStateManager;

        [Inject]
        private void Construct (GameConfig config, GameStateManager gameStateManager)
        {
            _settings = config;
            _gameStateManager = gameStateManager;
        }
         
        private void FixedUpdate()
        {
            MoveObj();
        }

        private void MoveObj()
        {
            if (_gameStateManager.CurrentGameState == GameState.Play)
            {
                gameObject.transform.Translate(Vector3.back *  _settings.TileSpeed * Time.fixedDeltaTime);
            }
        }
    }
}