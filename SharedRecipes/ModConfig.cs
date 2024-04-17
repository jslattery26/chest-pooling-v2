using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace SharedRecipes
{
    internal class ModConfig
    {

        public bool ShareCrafting { get; set; } = true;
        public bool ShareCooking { get; set; } = true;

        public ModControlsConfig Keys { get; set; } = new();
    }

    internal class ModControlsConfig
    {
        public KeybindList SyncRecipes { get; set; } = new(keybinds: [new Keybind(SButton.LeftShift, SButton.S, SButton.R)]);
    }

}