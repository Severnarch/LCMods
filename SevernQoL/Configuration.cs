using BepInEx.Configuration;

namespace SevernQoL
{
    internal class Configuration
    {
        public static ConfigEntry<bool> KiloWeightEnabled;

        public static void Load()
        {
            KiloWeightEnabled = SevernQoLBase.config.Bind<bool>("Visual", "KiloWeightEnabled", false, "Whether to display weight in metric kilograms instead of imperial pounds.");
        }
    }
}
