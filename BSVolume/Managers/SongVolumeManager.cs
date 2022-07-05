using System;
using UnityEngine;
using Zenject;
using SiraUtil.Logging;

namespace BSVolume.Managers
{
    internal class SongVolumeManager : IInitializable
    {
        private readonly GameplayCoreSceneSetupData _sceneSetupData;
        private readonly AudioTimeSyncController _audioTimeSyncController;
        private readonly SiraLog _log;
        private readonly Config _config;

        public SongVolumeManager(GameplayCoreSceneSetupData sceneSetupData, AudioTimeSyncController audioTimeSyncController, SiraLog log, Config config)
        {
            this._sceneSetupData = sceneSetupData;
            this._audioTimeSyncController = audioTimeSyncController;
            this._log = log;
            this._config = config;
        }

        public void Initialize()
        {
            _log.Info("In SongVolumeManager");
            var src = _audioTimeSyncController.GetComponent<AudioSource>();
            src.volume = _config.songVolume;

        }
    }
}
