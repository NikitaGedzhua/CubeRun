using Gedjua.Runner.Game.Data;
using Zenject;

namespace Gedjua.Runner.Installers
{
    public class SceneMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallJsonReader();
        }

        private void InstallJsonReader()
        {
            Container.BindInterfacesAndSelfTo<ReadMatchData>().FromNew().AsSingle().NonLazy();
        }
    }
}
