using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

internal static class EnergyMixinPatch
{
    internal static void Patch(Harmony harmony)
    {
        MethodInfo energyMixStartMethod = AccessTools.Method(typeof(EnergyMixin), nameof(EnergyMixin.Awake));
        MethodInfo startPrefixMethod = AccessTools.Method(typeof(EnergyMixinPatch), nameof(EnergyMixinPatch.AwakePrefix));
        var harmonyStartPrefix = new HarmonyMethod(startPrefixMethod);
        harmony.Patch(energyMixStartMethod, prefix: harmonyStartPrefix);
    }
    public static void AwakePrefix(ref EnergyMixin __instance)
    {
        Debug.Log("Добавляю батарейки в список подходящих для инструментов");
        List<TechType> compatibleBatteries = __instance.compatibleBatteries;
        List<TechType> existingTechtypes = new List<TechType>();

        if(compatibleBatteries.Contains(TechType.Battery) || compatibleBatteries.Contains(TechType.PrecursorIonBattery))
        {
            compatibleBatteries.Add(МеднаяБатарейка.Info.TechType);
        }
    }
}
