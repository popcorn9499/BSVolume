using System;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;

using Zenject;
using BSVolume.Views;

namespace BSVolume.Managers
{
    internal class VolumeMenuManager : IInitializable, IDisposable
    {
        private readonly VolumeMenuView _volumeMenuView;

        public VolumeMenuManager(VolumeMenuView volumeMenuView)
        {
            _volumeMenuView = volumeMenuView;
        }

        public void Dispose()
        {
            if (GameplaySetup.IsSingletonAvailable)
            {
                GameplaySetup.instance.RemoveTab("BSVolume");
            }
        }

        public void Initialize()
        {
            GameplaySetup.instance.AddTab("BSVolume", "BSVolume.Views.VolumeMenuView.bsml", _volumeMenuView);
        }


    }
}