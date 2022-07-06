using BSVolume.Managers;
using Zenject;

namespace BSVolume.Installers
{
    internal class CoreInstaller : Installer
    {
        private readonly Config _config;

        public CoreInstaller(Config config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle(); //stores the config for zenject so we can request the config
        }
    }
}
