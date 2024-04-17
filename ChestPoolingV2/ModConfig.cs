using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace ChestPoolingV2
{
    internal class ModConfig
    {
        public ModControlsConfig Keys { get; set; } = new();
    }

    internal class ModControlsConfig
    {
        public KeybindList DisablePoolingToggle { get; set; } = new(SButton.O);
    }
}