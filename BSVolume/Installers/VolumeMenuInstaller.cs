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


            Container.BindInterfacesAndSelfTo<MenuVolumeManager>().AsSingle();

            Container.Bind<VolumeMenuView>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesTo<VolumeMenuManager>().AsSingle();
        }

    }
}
