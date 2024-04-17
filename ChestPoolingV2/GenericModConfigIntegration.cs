using System;
using System.Linq;
using StardewModdingAPI;
using jslattery26.Common;
using jslattery26.Common.Integrations;

namespace ChestPoolingV2
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
            api.AddSectionTitle(manifest, () => "Controls");
            api.AddKeybindList(
                manifest,
                name: () => "Toggle Chest Pooling",
                tooltip: () => "Key to toggle disabling chest pooling.",
                getValue: () => getConfig().Keys.DisablePoolingToggle,
                setValue: value => getConfig().Keys.DisablePoolingToggle = value
            );

        }
    }
}