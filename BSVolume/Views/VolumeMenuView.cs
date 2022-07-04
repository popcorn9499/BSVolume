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
        [Inject]
        public void Construct(SiraLog log, AudioManagerSO audioManager, MainSettingsModelSO mainSettingsModelSO, Config config)
        {
            _log = log;
            _audioManager = audioManager;
            _mainSettingsModelSO = mainSettingsModelSO;
            _config = config;
            //_audioTimeSyncController = audioTimeSyncController;
        }

        [UIValue("gameVolume")]
        public float gameVolume = 0.5f;


        [UIAction("setGameVolume")]
        public void setGameVolume(float value)
        {
            gameVolume = value;
            Plugin.Log.Info($"game-value value applied, now: {gameVolume}");

            _config.songVolume = value;
        }

        [UIAction("#post-parse")]
        internal void PostParse()
        {
            // Code to run after BSML finishes
        }
    }
}
