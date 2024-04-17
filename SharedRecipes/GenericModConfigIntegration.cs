using System;
using System.Linq;
using StardewModdingAPI;
using jslattery26.Common;
using jslattery26.Common.Integrations;

namespace SharedRecipes
{
    /// <summary>Configures the integration with Generic Mod Config Menu.</summary>
    internal static class GenericModConfigMenuIntegration
    {
        public static void Register(IManifest manifest, IModRegistry modRegistry, IMonitor monitor, Func<ModConfig> getConfig, Action reset, Action save)
        {
            IGenericModConfigMenuApi api = IntegrationHelper.GetGenericModConfigMenu(modRegistry, monitor);
            if (api == null)
                return;
            api.Register(manifest, reset, save);
            api.AddSectionTitle(manifest, () => "Shared Recipes Options");
            api.AddBoolOption(
                manifest,
                name: () => "Share crafting Recipes",
                tooltip: () => "Share crafting recipes with all farmers automatically",
                getValue: () => getConfig().ShareCrafting,
                setValue: value => getConfig().ShareCrafting = value
            );
            api.AddBoolOption(
                manifest,
                name: () => "Share cooking Recipes",
                tooltip: () => "Share cooking recipes with all farmers automatically",
                getValue: () => getConfig().ShareCooking,
                setValue: value => getConfig().ShareCooking = value
            );
            api.AddSectionTitle(manifest, () => "Shared Recipes Keybinds");
            api.AddKeybindList(
                manifest,
                name: () => "Sync Recipes",
                tooltip: () => "Sync recipes with all farmers",
                getValue: () => getConfig().Keys.SyncRecipes,
                setValue: value => getConfig().Keys.SyncRecipes = value
            );
        }
    }
}