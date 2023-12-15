using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SevernQoL.Patches;

namespace SevernQoL
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class SevernQoLBase : BaseUnityPlugin
    {
        private const string NAME = PluginInfo.PLUGIN_NAME;
        private const string VERSION = PluginInfo.PLUGIN_VERSION;
        private const string GUID = "io.github.severnarch.LCMods." + NAME;

        private readonly Harmony harmony = new Harmony(GUID);
        private static ManualLogSource logSource;
        public static ConfigFile config;
        public static SevernQoLBase instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            logSource = BepInEx.Logging.Logger.CreateLogSource(NAME);
            logSource.LogMessage($"Preparing {NAME} v{VERSION}...");

            config = Config;
            Configuration.Load();

            logSource.LogDebug($"Patching all {NAME} patches...");

            harmony.PatchAll(typeof(SevernQoLBase));
            harmony.PatchAll(typeof(HUDManagerPatch));

            logSource.LogDebug($"Patched all {NAME} patches!");

            logSource.LogMessage($"Prepared {NAME}!");
        }
    }
}
