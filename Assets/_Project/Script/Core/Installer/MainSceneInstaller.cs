using _Project.Script.Core.EntryPoints;
using UnityEngine;
using Zenject;

namespace _Project.Script.Core.Installer
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private RootCanvas _rootCanvas;
        [SerializeField] private EventView _eventView;

        public override void InstallBindings()
        {
            BindCore();
            BindUI();
        }

        private void BindCore()
        {
            Container.BindInterfacesAndSelfTo<MainSceneEntryPoint>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JsonService>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameEventProvider>().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<RootCanvas>().FromComponentInNewPrefab(_rootCanvas).AsSingle();
            Container.BindInterfacesAndSelfTo<EventView>().FromInstance(_eventView).AsSingle();
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EventPresenter>().AsSingle();
        }
    }
}