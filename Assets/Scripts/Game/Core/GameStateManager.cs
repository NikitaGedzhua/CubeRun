using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Player;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Core
{
    public delegate void OnStateChange();
    
    public class GameStateManager : MonoBehaviour
    {
        private Hero _hero;
        private MatchDataSave _dataSaver;
        public event OnStateChange OnStateChanged;
       
        public GameState CurrentGameState { get; private set; }
        public bool PlayerIsAlive => _hero.IsAlive;

        [Inject]
        public void Constructor(Hero hero, MatchDataSave dataSaver)
        {
            _hero = hero;
            _dataSaver = dataSaver;
        }
        
        public void SetGameState(GameState state)
        {
            if (state == CurrentGameState) return;
            if (state == GameState.End)
                EndGameState();
            CurrentGameState = state;
            OnStateChanged?.Invoke();
        }

        private void EndGameState()
        {
            _dataSaver.SaveDataToJson();
        }
    }
}