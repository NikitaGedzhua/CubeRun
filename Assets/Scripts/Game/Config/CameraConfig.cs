using System;
using UnityEngine;

namespace Gedjua.Runner.Game.Config
{ 
    [Serializable] 
    public class CameraConfig
    {
        [Header("Cinemachine Settings")]
        public float CameraShakeIntensity;
        public float CameraShakeTime;
        public float CameraBoostFOV;
        public float CameraBoostOffsetY;
        public float CameraChangeViewTime;
    }
}