using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Road
{
    public class Obstacle : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<Obstacle> {}
    }
}