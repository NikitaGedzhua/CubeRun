using Gedjua.Runner.Game.Core;
using Gedjua.Runner.Game.Data;
using Gedjua.Runner.Interface;
using UnityEngine;
using Zenject;

namespace Gedjua.Runner.Installers
{
    public class StatsDataInstaller : MonoInstaller
    {
        [SerializeField] private GameStateManager _gameStateManager;
        
        public override void InstallBindings()
        {
            InstallGameManager();
            InstallScoreDistance();
            InstallScoreCoins();
            InstallDataSaver();
            InstallJsonSaver();
        }

        private void InstallScoreCoins()
        {
            Container.BindInterfacesAndSelfTo<ScoreCoins>().FromNew().AsSingle().NonLazy();
        }
   
        private void InstallScoreDistance()
        {
            Container.BindInterfacesAndSelfTo<ScoreDistance>().FromNew().AsSingle().NonLazy();
        }
        
        private void InstallDataSaver()
        {
            Container.Bind<MatchDataSave>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MatchDataSetter>().FromNew().AsSingle().NonLazy();
        }

        private void InstallGameManager()
        {
            Container.Bind<GameStateManager>().FromInstance(_gameStateManager).AsSingle().NonLazy();
        }
        
        private void InstallJsonSaver()
        {
            Container.Bind<IDataProviderService>().To<LocalDataSaver>().AsSingle();
        }
    }
}