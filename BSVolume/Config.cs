using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BSVolume
{
    internal class Config
    {
        public virtual float songVolume { get; set; } = 1f;
        public virtual float songPreviewVolume { get; set; } = 1f;
        public virtual float ambienceVolume { get; set; } = 1f;

        public virtual bool gamePrevLock { get; set; } = false;
    }
}
