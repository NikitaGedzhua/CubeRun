using Gedjua.Runner.Enums;
using UnityEngine;

namespace Gedjua.Runner.Game.Road
{
    public class RoadObject : MonoBehaviour
    {
        [SerializeField] private RoadObjects roadObjects;
       
       public RoadObjects RoadObjects => roadObjects;
    }
}
