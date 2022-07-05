using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BSVolume
{
    internal class Config
    {
        public virtual float songVolume { get; set; } = 0.8f;
        public virtual float songPreview { get; set; } = 0.8f;

        public virtual float backgroundPreview { get; set; } = 0.8f;
    }
}
