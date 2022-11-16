using Gedjua.Runner.Game.Data;
using Gedjua.Runner.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gedjua.Runner.Game.UI
{
    public class StartGameScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textDistance;
        [SerializeField] private TextMeshProUGUI _textCoins;
        [SerializeField] private TextMeshProUGUI _textName;
        [SerializeField] private TMP_InputField _inputFieldName;
        [SerializeField] private Button _startButton;
        
        private readonly SceneController _sceneController = new();
        private readonly RandomNameGenerator _randomNameGenerator = new();
        private MatchData _matchData;
        private string _name;
        
        [Inject]
        public void Construct(MatchData matchData)
        {
            _matchData = matchData;
        }
        
         private void Start()
        {
            SetRandomName();
            SetStats();
            _startButton.onClick.AddListener(StartButtonAction);
        }

         private void SetRandomName()
        {
            _name = _randomNameGenerator.GetRandomName();
            _inputFieldName.text = _name;
        }
        
        private void SetStats()
        {
            _textCoins.text = _matchData.LastCoins.ToString();
            _textDistance.text = _matchData.LastDistance.ToString();
            _textName.text = _matchData.LastPlayerName;
        }
        
        private void StartButtonAction()
        {
            SetNameData();
            MoveToNextScene();
        }

        private void SetNameData()
        {
            _matchData.Name = _inputFieldName.text;
        }
        
        private void MoveToNextScene()
        {
            _sceneController.NextScene();
        }
    }
}
