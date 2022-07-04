using BSVolume.Managers;
using Zenject;

namespace BSVolume.Installers
{
    internal class SongVolumeInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SongVolumeManager>().AsSingle();

        }
    }
}
