using System.Linq;
using BSVolume.Views;
using BSVolume.Managers;
using IPA.Loader;
using Zenject;

namespace BSVolume.Installers
{
    internal class VolumeMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuVolumeManager>().AsSingle(); //handles applying the menu volume changes we want. 

            Container.Bind<VolumeMenuView>().FromNewComponentAsViewController().AsSingle(); //handles the view we interact with for our menu.
            Container.BindInterfacesTo<VolumeMenuManager>().AsSingle(); //handles creating the tab for our new menu view
        }
    }
}
