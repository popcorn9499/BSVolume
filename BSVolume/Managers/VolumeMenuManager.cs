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
        private readonly VolumeMenuView _flowCoordinator;
        private readonly MainFlowCoordinator _mainFlowCoordinator;
        private readonly MenuButton _menuButton;

        public VolumeMenuManager(MainFlowCoordinator mainFlowCoordinator, VolumeMenuView flowCoordinator)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _flowCoordinator = flowCoordinator;
        }

        public void Dispose()
        {
            if (GameplaySetup.IsSingletonAvailable)
            {
                GameplaySetup.instance.RemoveTab("ME");
            }
        }

        public void Initialize()
        {
            Plugin.Log.Info("HEYOO");
            GameplaySetup.instance.AddTab("BSVolume", "BSVolume.Views.VolumeMenuView.bsml", _flowCoordinator);
        }


    }
}