using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
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
        private Config _config;

        private float _gameVolume = 0f;
        private float _prevVolume = 0f;
        private float _backgroundVolume = 0f;


        [UIValue("gameVolume")]
        public float gameVolume
        {
            get => _gameVolume;
            set
            {
                if (_gameVolume != value)
                {
                    _gameVolume = value;
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

        [UIValue("backgroundVolume")]
        public float backgroundVolume
        {
            get => _backgroundVolume;
            set
            {
                if (_backgroundVolume != value)
                {
                    _backgroundVolume = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [Inject]
        public void Construct(SiraLog log, AudioManagerSO audioManager, MainSettingsModelSO mainSettingsModelSO, Config config)
        {
            _log = log;
            _audioManager = audioManager;
            _mainSettingsModelSO = mainSettingsModelSO;
            _config = config;
            gameVolume = _config.songVolume;
            //_audioTimeSyncController = audioTimeSyncController;
        }

        


        [UIAction("setGameVolume")]
        public void setGameVolume(float value)
        {
            gameVolume = value;
            _log.Info($"game-value value applied, now: {gameVolume}");
            _config.songVolume = value;
        }

        [UIAction("#post-parse")]
        internal void PostParse()
        {
            // Code to run after BSML finishes
        }
    }
}
