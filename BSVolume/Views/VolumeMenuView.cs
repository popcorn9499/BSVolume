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
        [Inject]
        public void Construct(SiraLog log, AudioManagerSO audioManager, MainSettingsModelSO mainSettingsModelSO)
        {
            _log = log;
            _audioManager = audioManager;
            _mainSettingsModelSO = mainSettingsModelSO;
            //_audioTimeSyncController = audioTimeSyncController;
        }

        [UIValue("gameVolume")]
        public float gameVolume = 0.5f;


        [UIAction("setGameVolume")]
        public void setGameVolume(float value)
        {
            gameVolume = value;
            Plugin.Log.Info($"game-value value applied, now: {gameVolume}");
            
            //min volume
            /*
            _audioManager.musicVolume = -30f;
            _audioManager.mainVolume = -30f;
            _audioManager.sfxVolume = -30f;
            */
            //Plugin.Log.Info(AudioHelpers.NormalizedVolumeToDB(value).ToString());
            //_audioManager.musicVolume = 4f;
            //_audioManager.mainVolume = AudioHelpers.NormalizedVolumeToDB(value);
            /*
            Plugin.Log.Info("Prev Value " + _mainSettingsModelSO.volume.value.ToString());
            _mainSettingsModelSO.volume.value = value;
            _mainSettingsModelSO.Save();
            _mainSettingsModelSO.Load(true);
            Plugin.Log.Info("Post Value " + _mainSettingsModelSO.volume.value.ToString());
            */
            
            //_audioManager.sfxVolume = 4f;

            /*
            var src = _audioTimeSyncController.GetComponent<AudioSource>();
            _log.Info("Original Volume: " + src.volume);
            src.volume = value;
            _log.Info("Set volume to "+ value + " is? " + src.volume);
            */
        }

        [UIAction("#post-parse")]
        internal void PostParse()
        {
            // Code to run after BSML finishes
        }
    }
}
