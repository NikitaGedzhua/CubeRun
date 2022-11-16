using UnityEngine;

namespace Gedjua.Runner.Interface
{
    public interface IPositionGenerator
    {
       public Vector3 GeneratePosition(float spawnPos);
    }
}

