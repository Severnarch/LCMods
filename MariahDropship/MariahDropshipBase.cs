using LCSoundTool;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using System;
using UnityEngine.Networking;

namespace MariahDropship
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class MariahDropshipBase : BaseUnityPlugin
    {
        private const string NAME = PluginInfo.PLUGIN_NAME;
        private const string VERSION = PluginInfo.PLUGIN_VERSION;
        private const string GUID = "io.github.severnarch.LCMods." + NAME;

        private readonly Harmony harmony = new Harmony(GUID);
        private static ManualLogSource logSource;
        public static MariahDropshipBase instance;

        private async void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            logSource = BepInEx.Logging.Logger.CreateLogSource(NAME);
            logSource.LogMessage($"Preparing {NAME} v{VERSION}...");

            logSource.LogDebug($"Patching all {NAME} patches...");

            harmony.PatchAll(typeof(MariahDropshipBase));

            string audioPath = Path.Combine(Paths.PluginPath, "MariahDropship");
            AudioClip MCSound = await LoadClip(Path.Combine(audioPath, "ship.wav"));
            SoundTool.ReplaceAudioClip("IcecreamTruckV2Christmas", MCSound);
            SoundTool.ReplaceAudioClip("IcecreamTruckV2ChristmasFar", MCSound);

            logSource.LogDebug($"Patched all {NAME} patches!");

            logSource.LogMessage($"Prepared {NAME}!");
        }
        private async Task<AudioClip> LoadClip(string path)
        {
            AudioClip clip = null;
            UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, (AudioType)20);
            try
            {
                uwr.SendWebRequest();
                try
                {
                    while (!uwr.isDone)
                    {
                        await Task.Delay(5);
                    }
                    if ((int)uwr.result == 2 || (int)uwr.result == 3 || (int)uwr.result == 4)
                    {
                        logSource.LogError((object)(uwr.error ?? ""));
                    }
                    else
                    {
                        clip = DownloadHandlerAudioClip.GetContent(uwr);
                    }
                }
                catch (Exception ex)
                {
                    logSource.LogError((object)(ex.Message + ", " + ex.StackTrace));
                }
            }
            finally
            {
                ((IDisposable)uwr)?.Dispose();
            }
            return clip;
        }
    }
}
