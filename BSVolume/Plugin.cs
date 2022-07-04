using System.IO;
using BSVolume.Installers;
using IPA;
using IPAConfig = IPA.Config.Config;
using IPA.Config.Stores;
using IPA.Utilities;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using Conf = IPA.Config.Config;

namespace BSVolume
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        /// <summary>
        /// Use to send log messages through BSIPA.
        /// </summary>
        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(Conf conf, IPALogger logger, Zenjector zenjector)
        {
            Instance = this;
            Log = logger;
            zenjector.UseLogger(logger);

            Config config = conf.Generated<Config>();
            zenjector.Install<CoreInstaller>(Location.App, config);
            zenjector.Install<VolumeMenuInstaller>(Location.Menu);
            zenjector.Install<SongVolumeInstaller>(Location.Player);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Plugin.Log.Info("OnApplicationStart");
        }

        [OnExit]
        public void OnApplicationQuit()
        {

        }

    }
}
