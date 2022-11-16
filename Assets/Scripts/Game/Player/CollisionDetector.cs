using System;
using Gedjua.Runner.Enums;
using Gedjua.Runner.Game.Road;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Game.Player
{
    public class CollisionDetector : MonoBehaviour
    {
        private Hero _hero;
        private float _coinScore;
        public event Action<RoadObject> CollidedObject;

        [Inject]
        private void Constructor(Hero hero)
        {
            _hero = hero;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            var collideObj = collision.gameObject.GetComponent<RoadObject>();
            if (collideObj == null) return;
            CollidedObject?.Invoke(collideObj);

            if (collideObj.RoadObjects == RoadObjects.Obstacle)
            {
                _hero.ObstacleHit();
            }
        }
    }
}


