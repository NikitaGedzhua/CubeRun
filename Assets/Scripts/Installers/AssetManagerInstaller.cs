using Gedjua.Runner.Game.Core;
using Zenject;

public class AssetManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AssetsManager>().FromNew().AsSingle().NonLazy();
    }
}
