using Gedjua.Runner.Game.Core;
using Gedjua.Runner.Game.Player;
using Gedjua.Runner.Game.Road;
using Zenject;

namespace Gedjua.Runner.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        private Hero _player;
        private AssetsManager _assetsManager;
       
        [Inject]
        public void Constructor(AssetsManager assetsManager)
        {
            _assetsManager = assetsManager;
        }

        public override  void InstallBindings()
        {
            InstallTileBoostHandler();
            InstallPlayer();
            InstallPlayerSwipeController();
        }

        private void InstallTileBoostHandler()
        {
            Container.BindInterfacesAndSelfTo<TileSpeedBoost>().FromNew().AsSingle().NonLazy();
        } 
        
        private  void InstallPlayer()
        {
            _player = Container.InstantiatePrefabForComponent<Hero>(_assetsManager.GetHero());
            
            Container.Bind<Hero>().FromInstance(_player).AsSingle();
            Container.Bind<PlayerMoveController>().FromNewComponentOn(_player.gameObject).AsSingle();
            Container.Bind<CollisionDetector>().FromNewComponentOn(_player.gameObject).AsSingle();
        }

        private void InstallPlayerSwipeController()
        {
            Container.BindInterfacesAndSelfTo<InputController>().FromNew().AsSingle();
        }
    }
}
