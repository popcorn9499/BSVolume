using UnityEngine;
using Zenject;
using SiraUtil.Logging;
using IPA.Utilities;

namespace BSVolume.Managers
{
    //basically a duplicate from the enhancements mod by auros. Just wanted to change the menu location for the preview volume
    internal class MenuVolumeManager : IInitializable
    {
        private SongPreviewPlayer _songPreviewPlayer; //store the song preview player so we can adjust volumes in that
        private readonly Config _config;
        private readonly SiraLog _log;
        private static readonly FieldAccessor<SongPreviewPlayer, float>.Accessor PreviewVolume = FieldAccessor<SongPreviewPlayer, float>.GetAccessor("_volumeScale"); //get the regular volume for song previews
        private static readonly FieldAccessor<SongPreviewPlayer, AudioClip>.Accessor DefaultAudioClip = FieldAccessor<SongPreviewPlayer, AudioClip>.GetAccessor("_defaultAudioClip"); //adjust the main default audio clip at menu
        

        public MenuVolumeManager(SiraLog log, Config config, SongPreviewPlayer songPreviewPlayer)
        {
            _config = config;
            _songPreviewPlayer = songPreviewPlayer;
            _log = log;
        }

        public void Initialize()
        {
            SetMenuVolume(_config.songPreviewVolume);
            SetMenuAmbienceVolume(_config.ambienceVolume);
        }
        
        //allow us to set a new preview song level
        public void SetMenuVolume(float volume)
        {
            PreviewVolume(ref _songPreviewPlayer) = volume;
        }

        //allows us to set the menu ambience volume. so the main menu music
        public void SetMenuAmbienceVolume(float volume)
        {
            var audioClip = DefaultAudioClip(ref _songPreviewPlayer);
            try //catching the nullpointerexception caused by setting this too early
            {
                _songPreviewPlayer.CrossfadeTo(audioClip, AudioHelpers.NormalizedVolumeToDB(volume), Mathf.Max(Random.Range(0f, audioClip.length - 0.1f), 0f), -1f, true, null);
                _log.Info("Successfully set ambience volume!");
            }
            catch
            {
                _log.Debug("Failed to set ambience volume!");
            }
        }
    }
}
