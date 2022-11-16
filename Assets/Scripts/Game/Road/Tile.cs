using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Road
{
    public class Tile : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Tile> {}
    }
}