using Gedjua.Runner.Game.Config;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameConfig gameConfig;
        public RoadObjConfig roadObjConfig;
        public PlayerConfig playerConfig;
        public DataConfig dataConfig;
        public CameraConfig cameraConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(gameConfig);
            Container.BindInstance(roadObjConfig);
            Container.BindInstance(playerConfig);
            Container.BindInstance(dataConfig);
            Container.BindInstance(cameraConfig);
        }
    }
}

