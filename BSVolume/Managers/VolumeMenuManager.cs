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
        private readonly VolumeMenuView _volumeMenuView; //the volumemenuview for the actual menu

        public VolumeMenuManager(VolumeMenuView volumeMenuView)
        {
            _volumeMenuView = volumeMenuView; 
        }

        public void Dispose()
        {
            if (GameplaySetup.IsSingletonAvailable) //no clue why this is here
            {
                GameplaySetup.instance.RemoveTab("BSVolume"); //removing the volume tab
            }
        }

        public void Initialize()
        {
            GameplaySetup.instance.AddTab("BSVolume", "BSVolume.Views.VolumeMenuView.bsml", _volumeMenuView); //adding the volume tab
        }


    }
}