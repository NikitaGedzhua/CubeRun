using Gedjua.Runner.Game.Core;
using Gedjua.Runner.Game.Data;
using Gedjua.Runner.Interface;
using Gedjua.Runner.Services;
using Zenject;

namespace Gedjua.Runner.Installers
{
    public class GameStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MatchData>().AsSingle().NonLazy();
            Container.Bind<IAssetLoadService>().To<LocalAssetProvider>().AsSingle().NonLazy();
            Container.Bind<IConfigService>().To<LocalConfigProvider>().AsSingle();
            Container.Bind<GameConfigSetter>().AsSingle().NonLazy();
            Container.Bind<AssetsLoader>().AsSingle().NonLazy();
        }
    }
}
