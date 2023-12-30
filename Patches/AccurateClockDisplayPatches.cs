using HarmonyLib;

namespace AccurateClockDisplay.Patches
{
    [HarmonyPatch]
    class AccurateClockDisplayPatches
    {
        [HarmonyPatch(typeof(TimeOfDay), "Update")]
        [HarmonyPostfix]
        public static void Update(TimeOfDay __instance)
        {
            if (!GameNetworkManager.Instance.localPlayerController.isInsideFactory && !GameNetworkManager.Instance.localPlayerController.isInHangarShipRoom)
                HUDManager.Instance.SetClock(__instance.normalizedTimeOfDay, __instance.numberOfHours, true);
        }
    }
}