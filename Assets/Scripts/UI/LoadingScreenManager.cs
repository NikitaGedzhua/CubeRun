using Gedjua.Runner.Game.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.UI
{
    public class LoadingScreenManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _progressText;

        private readonly SceneController _sceneController = new();
        private AssetsLoader _assetsLoader;

        private const string StartLoadText = "Loading in progress";
        private const string CompleteLoadText = "Loading complete";

        [Inject]
        public void Constructor(AssetsLoader assetsLoader)
        {
            _assetsLoader = assetsLoader;
        }

        private async void Start()
        {
            _progressText.text = StartLoadText;

            await _assetsLoader.LoadAssetsAsync();
            _progressText.text = CompleteLoadText;

            LoadGameScene();
        }

        private void LoadGameScene()
        {
            _sceneController.NextScene();
        }
    }
}
