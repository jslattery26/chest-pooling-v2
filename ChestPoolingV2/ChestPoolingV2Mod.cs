using System.Collections.Generic;
using System.Linq;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Objects;
using HarmonyLib;

#nullable enable

namespace ChestPoolingV2
{
    public class ChestPoolingV2Mod : Mod
    {
        public static IMonitor? StaticMonitor { get; private set; }

        public static void Log(string s, LogLevel l = LogLevel.Trace) => StaticMonitor?.Log(s, l);

        public override void Entry(IModHelper helper)
        {
            StaticMonitor = Monitor;
            ChestPatches.Initialize(Monitor);
            Harmony Harmony = new(ModManifest.UniqueID);
            Harmony.Patch(
                original: AccessTools.Method(typeof(Chest), nameof(Chest.grabItemFromInventory)),
                prefix: new HarmonyMethod(typeof(ChestPatches), nameof(ChestPatches.Chest_grabItemFromInventory_Prefix))
            );

        }

        public static bool SearchForBestChest(Chest _, List<Chest> chestList, Item itemRemoved, Farmer who)
        {
            Log($"Checking {chestList.Count} chests");

            Chest? bestChest = chestList.GetBestChest(itemRemoved);
            if (bestChest == null)
            {
                Log("No best chest found, keeping in current chest.");
                return true;
            }
            Log($"Best chest found: {bestChest.Items.Select(i => i.Name).Aggregate((a, b) => a + ", " + b)}");
            bestChest.GrabItemFromInventoryFromOtherChest(itemRemoved, who);
            Log("Overrode default behavior..");
            return false;
        }
    }
}
