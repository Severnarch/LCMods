using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace LethalArch
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class LethalArchBase : BaseUnityPlugin
    {
        private const string NAME = PluginInfo.PLUGIN_NAME;
        private const string VERSION = PluginInfo.PLUGIN_VERSION;
        private const string GUID = "io.github.severnarch.LCMods." + NAME;

        private readonly Harmony harmony = new Harmony(GUID);
        public static ManualLogSource logSource;
        public static LethalArchBase instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            logSource = BepInEx.Logging.Logger.CreateLogSource(NAME);
            logSource.LogMessage($"Preparing {NAME} v{VERSION}...");

            logSource.LogDebug($"Patching all {NAME} patches...");

            harmony.PatchAll(typeof(RoundData));

            logSource.LogDebug($"Patched all {NAME} patches!");

            logSource.LogMessage($"Prepared {NAME}!");
        }
    }
}
