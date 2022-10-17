using System;
using UnityEngine;
using Zenject;
using SiraUtil.Logging;

namespace BSVolume.Managers
{
    internal class SongVolumeManager : IInitializable
    {
        private readonly AudioTimeSyncController _audioTimeSyncController;//for adjusting game song volume
        private readonly SiraLog _log;
        private readonly Config _config;

        public SongVolumeManager(AudioTimeSyncController audioTimeSyncController, SiraLog log, Config config)
        {
            this._audioTimeSyncController = audioTimeSyncController; 
            this._log = log;
            this._config = config;
        }

        public void Initialize() //load each time the game loads and set the volume
        {
            _log.Info("Setting the new volume for game");
            AudioSource src = _audioTimeSyncController.GetComponent<AudioSource>(); 
            src.volume = _config.songVolume * _config.masterSongVolume;

        }
    }
}
