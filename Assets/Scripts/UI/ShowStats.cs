using Gedjua.Runner.Game.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.UI
{
    public class ShowStats : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textDistance;
        [SerializeField] private TextMeshProUGUI _textCoins;
        private MatchData _matchData;
        private int _dist;
        private int _coins;

        [Inject]
        private void Construct(MatchData matchData)
        {
            _matchData = matchData;
        }
        
        private void Update()
        {
            ShowScores();
        }
   
        private void ShowScores()
        {
            _dist = (int)_matchData.Distance;
            _coins = (int)_matchData.Coins;
            _textDistance.text = _dist.ToString();
            _textCoins.text = _coins.ToString();
        }
    }
}

