using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using BSVolume.Managers;
using SiraUtil.Logging;
using UnityEngine;
using Zenject;

//the menu view for setting volume levels


namespace BSVolume.Views
{
    [HotReload(RelativePathToLayout = @"./VolumeMenuView.bsml")] //point to my bsml file for this menu
    [ViewDefinition("BSVolume.Views.VolumeMenuView.bsml")]

    internal class VolumeMenuView : BSMLAutomaticViewController
    {
        private SiraLog _log;
        private MenuVolumeManager _menuVolumeManager; //stores the menu volume manager for adjusting preview and main menu track volumes
        private Config _config;

        private float _songVolume = 0f;
        private float _prevVolume = 0f;
        private float _ambienceVolume = 0f;
        private float _masterSongVolume = 0f;

        [UIValue("masterSongVolume")]
        public float masterSongVolume
        {
            get => _masterSongVolume;
            set
            {
                if (_songVolume != value)
                {
                    _log.Info($"game-value value applied, now: {value}");
                    _config.masterSongVolume = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [UIValue("songVolume")]
        public float songVolume
        {
            get => _songVolume;
            set
            {
                if (_songVolume != value)
                {
                    _log.Info($"game-value value applied, now: {value}");
                    _config.songVolume = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [UIValue("previewVolume")]
        public float previewVolume
        {
            get => _prevVolume;
            set
            {
                if (_prevVolume != value)
                {
                    _log.Info($"preview-value value applied, now: {value}");
                    _config.songPreviewVolume = value;
                    _menuVolumeManager.SetMenuVolume(value);
                    NotifyPropertyChanged();
                }
            }
        }

        [UIValue("ambienceVolume")]
        public float ambienceVolume
        {
            get => _ambienceVolume;
            set
            {
                if (_ambienceVolume != value)
                {
                    _ambienceVolume = value;
                    _log.Info($"background-value value applied, now: {value}");
                    _config.ambienceVolume = value;
                    _menuVolumeManager.SetMenuAmbienceVolume(value);
                    NotifyPropertyChanged();
                }
            }
        }

        [Inject]
        public void Construct(SiraLog log, MenuVolumeManager menuVolumeManager, Config config)
        {
            _log = log;
            _config = config;
            _menuVolumeManager = menuVolumeManager;
            loadConf();

        }

        [UIAction("setMasterSongVolume")]
        public void setMasterVolume(float value)
        {
            masterSongVolume = value;
        }

        [UIAction("setSongVolume")]
        public void setGameVolume(float value)
        {
            songVolume = value;
        }

        [UIAction("setPreviewVolume")]
        public void setPreviewVolume(float value)
        {
            previewVolume = value;
        }

        [UIAction("setAmbienceVolume")]
        public void setAmbienceVolume(float value)
        {
            ambienceVolume = value;
        }

        //log information for fun?
        [UIAction("#post-parse")]
        internal void PostParse()
        {

            _log.Info("Welcome to my weird wacky mod!");
        }

        public void loadConf()
        {
            //apply the config to the menu
            songVolume = _config.songVolume;
            previewVolume = _config.songPreviewVolume;
            ambienceVolume = _config.ambienceVolume;
        }
    }
}
