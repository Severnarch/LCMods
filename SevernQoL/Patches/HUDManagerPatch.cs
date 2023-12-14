using HarmonyLib;
using UnityEngine;

namespace SevernQoL.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void UpdatePatch()
        {
            if (Configuration.KiloWeightEnabled.Value == true)
            {
                if (!GameNetworkManager.Instance.localPlayerController.isPlayerDead)
                {
                    float num2 = Mathf.RoundToInt(Mathf.Clamp(GameNetworkManager.Instance.localPlayerController.carryWeight - 1f, 0f, 100f) * 105f / 2.205f);
                    HUDManager.Instance.weightCounter.text = $"{num2} kg";
                    HUDManager.Instance.weightCounterAnimator.SetFloat("weight", num2 / 130f);
                }
            }
        }
    }
}
