using UnityEngine;
using UnityEngine.UI;

namespace Gedjua.Runner.Game.UI
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField] private Button _buttonBack;
        private SceneController _sceneController = new();
        private const int MainSceneIndex = 1;

        private void Awake()
        {
            _buttonBack.onClick.AddListener(LoadMainScene);
        }

        private void LoadMainScene()
        {
            _sceneController.LoadScene(MainSceneIndex);
        }
    }
}
