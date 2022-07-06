using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using BSVolume.Managers;
using SiraUtil.Logging;
using UnityEngine;
using Zenject;



namespace BSVolume.Views
{
    [HotReload(RelativePathToLayout = @"./VolumeMenuView.bsml")]
    [ViewDefinition("BSVolume.Views.VolumeMenuView.bsml")]

    internal class VolumeMenuView : BSMLAutomaticViewController
    {
        private SiraLog _log;
        private AudioManagerSO _audioManager;
        private MainSettingsModelSO _mainSettingsModelSO;
        private AudioTimeSyncController _audioTimeSyncController;
        private MenuVolumeManager _menuVolumeManager;
        private Config _config;

        private float _songVolume = 0f;
        private float _prevVolume = 0f;
        private float _ambienceVolume = 0f;


        [UIValue("gameVolume")]
        public float songVolume
        {
            get => _songVolume;
            set
            {
                if (_songVolume != value)
                {
                    _songVolume = value;
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
                    _prevVolume = value;
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
                    NotifyPropertyChanged();
                }
            }
        }

        [Inject]
        public void Construct(SiraLog log, AudioManagerSO audioManager, MainSettingsModelSO mainSettingsModelSO, MenuVolumeManager menuVolumeManager, Config config)
        {
            _log = log;
            _audioManager = audioManager;
            _mainSettingsModelSO = mainSettingsModelSO;
            _config = config;
            _menuVolumeManager = menuVolumeManager;

            songVolume = _config.songVolume;
            //_audioTimeSyncController = audioTimeSyncController;
        }

        


        [UIAction("setSongVolume")]
        public void setGameVolume(float value)
        {
            songVolume = value;
            _log.Info($"game-value value applied, now: {value}");
            _config.songVolume = value;
        }

        [UIAction("setPreviewVolume")]
        public void setPreviewVolume(float value)
        {
            previewVolume = value;
            _log.Info($"preview-value value applied, now: {value}");
            _config.songPreviewVolume = value;
            _menuVolumeManager.SetMenuVolume(value);
        }

        [UIAction("setAmbienceVolume")]
        public void setAmbienceVolume(float value)
        {
            ambienceVolume = value;
            _log.Info($"background-value value applied, now: {value}");
            _config.ambienceVolume = value;
            _menuVolumeManager.SetMenuAmbienceVolume(value);
        }

        [UIAction("#post-parse")]
        internal void PostParse()
        {
            // Code to run after BSML finishes
        }
    }
}
