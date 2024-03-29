﻿using System.IO;
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
        [Init]
        public Plugin(Conf conf, IPALogger logger, Zenjector zenjector)
        {
            zenjector.UseLogger(logger);

            Config config = conf.Generated<Config>();
            zenjector.Install<CoreInstaller>(Location.App, config); //handle storing the config for zenject
            zenjector.Install<SongVolumeInstaller>(Location.Player); //handle applying the song volume for in game

            zenjector.Install<VolumeMenuInstaller>(Location.Menu); //handle the actual menu you interact with
            //test
        }
    }
}
