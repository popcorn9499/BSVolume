using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using SiraUtil.Logging;
using Zenject;



namespace BSVolume.Views
{
    [HotReload(RelativePathToLayout = @"./VolumeMenuView.bsml")]
    [ViewDefinition("BSVolume.Views.VolumeMenuView.bsml")]
    internal class VolumeMenuView : BSMLAutomaticViewController
    {

        [UIValue("gameVolume")]
        public float gameVolume = 0.5f;


        [UIAction("setGameVolume")]
        public void setGameVolume(float value)
        {
            gameVolume = value;
            Plugin.Log.Info($"game-value value applied, now: {gameVolume}");
        }

        [UIAction("#post-parse")]
        internal void PostParse()
        {
            // Code to run after BSML finishes
        }
    }
}
