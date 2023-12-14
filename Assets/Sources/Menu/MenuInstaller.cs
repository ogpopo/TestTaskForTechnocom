using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private MenuView menuView;

    public override void InstallBindings()
    {
        Container.Bind<MainMenuSwitcher>().AsSingle().NonLazy();
        Container.Bind<Menu>().AsSingle().NonLazy();
        Container.Bind<MenuView>().FromInstance(menuView).AsSingle();
        Container.Bind<MenuPresenter>().AsSingle().NonLazy();
        //Container.Bind(typeof(IDisposable)).To<MenuPresenter>();
    }
}