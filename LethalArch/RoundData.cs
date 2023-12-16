using HarmonyLib;
using System.Runtime.CompilerServices;


namespace LethalArch
{
    [HarmonyPatch]
    public class RoundData
    {
        public static MoonLevel currentLevel = new MoonLevel(-1, "Unknown", "Unknown", null, "UnknownLevel");

        [HarmonyPatch(typeof(StartOfRound), "Update")]
        [HarmonyPrefix]
        private static void SORUpdatePatch()
        {
            int moonID = StartOfRound.Instance.currentLevelID;
            if (Enum.MoonInformation.ContainsKey(moonID)) {
                currentLevel = Enum.MoonInformation[moonID];
            }
            if (currentLevel == null || currentLevel.MoonID == -1)
            {
                currentLevel = new MoonLevel(-1, "Unknown", "Unknown", null, "UnknownLevel");
            }
        }
    }
}
