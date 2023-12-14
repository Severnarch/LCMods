
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace SevernQoL
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class SevernQoLBase : BaseUnityPlugin
    {
        private const string NAME = PluginInfo.PLUGIN_NAME;
        private const string VERSION = PluginInfo.PLUGIN_VERSION;
        private const string GUID = "io.github.severnarch.LCMods." + NAME;

        private readonly Harmony harmony = new Harmony(GUID);
        private SevernQoLBase instance;
        private ManualLogSource logSource;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            logSource = BepInEx.Logging.Logger.CreateLogSource(NAME);
            logSource.LogMessage($"Preparing {NAME} v{VERSION}...");

            logSource.LogDebug($"Patching all {NAME} patches...");
            harmony.PatchAll(typeof(SevernQoLBase));
            logSource.LogDebug($"Patched all {NAME} patches!");

            logSource.LogMessage($"Prepared {NAME}!");
        }
    }
}
