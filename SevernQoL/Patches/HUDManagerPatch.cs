using GameNetcodeStuff;
using HarmonyLib;
using System;
using TMPro;
using UnityEngine;

namespace SevernQoL.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {
        [HarmonyPatch(typeof(HUDManager), "Update")]
        [HarmonyPostfix]
        private static void UpdatePatch(ref TextMeshProUGUI ___weightCounter, ref Animator ___weightCounterAnimator)
        {
            if (Configuration.KiloWeightEnabled.Value == true)
            {
                if (!GameNetworkManager.Instance.localPlayerController.isPlayerDead)
                {
                    float num2 = Mathf.RoundToInt(Mathf.Clamp(GameNetworkManager.Instance.localPlayerController.carryWeight - 1f, 0f, 100f) * 105f / 2.205f);
                    ___weightCounter.text = $"{num2} kg";
                    ___weightCounterAnimator.SetFloat("weight", num2 / 130f);
                }
            }
        }
    }
}
