using System;

namespace Gedjua.Runner.Game.Data
{
    [Serializable]
    public class MatchData
    {
      [NonSerialized]  public float Coins;
      [NonSerialized]  public float Distance;
      [NonSerialized]  public string Name;
        
        public float LastCoins;
        public float LastDistance;
        public string LastPlayerName;
    }
}