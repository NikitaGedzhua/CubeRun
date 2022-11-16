using Gedjua.Runner.Game.Core;
using Gedjua.Runner.Game.UI;
using UnityEngine;
using Zenject;

namespace Game.Core
{
    public class PreloadSceneManager : MonoBehaviour
    {
        private readonly SceneController _sceneController = new();
        private GameConfigSetter _gameConfigSetter;

        [Inject]
        public void Constructor(GameConfigSetter gameConfigSetter)
        {
            _gameConfigSetter = gameConfigSetter;
        }
        
        private void Start()
        {
            _gameConfigSetter.SetConfigs();
            LoadMeinMenu();
        }
        
        private void LoadMeinMenu()
        {
            _sceneController.NextScene();
        }
    }
}