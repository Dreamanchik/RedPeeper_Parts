﻿using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using RedPeeper_Parts;
using System;
using System.Timers;
using UnityEngine;
using Ingredient = CraftData.Ingredient;

public static class DNASamplerInvalid
{
    public static PrefabInfo Info { get; } = PrefabInfo
        .WithTechType("DNASampler", "Максимально недоделанная вещь. Нет, вы её не сможете так легко получить.", "D")
        .WithIcon(SpriteManager.Get(TechType.HeatBlade));

    public static void Register()
    {
        var customPrefab = new CustomPrefab(Info);

        var yeetKnifeObj = new CloneTemplate(Info, TechType.Knife);
        yeetKnifeObj.ModifyPrefab += obj =>
        {
            //obj.AddComponent<HeatBlade>();
            var heatBlade = obj.GetComponent<Knife>();
            //var scannerComponent = obj.GetComponent<ScannerTool>();
            var yeetKnife = obj.AddComponent<DNASamplerData>().CopyComponent(heatBlade);
            UnityEngine.Object.DestroyImmediate(heatBlade);
            //Object.DestroyImmediate(scannerComponent);
            yeetKnife.damage *= 1f;
            yeetKnife.hasBashAnimation = false;
            //yeetKnife.attackSpeed *= 1f;
        };
        customPrefab.SetGameObject(yeetKnifeObj);
        customPrefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 2)));
        customPrefab.SetEquipment(EquipmentType.Hand);
        customPrefab.Register();
    }
}

public class DNASamplerData : Knife
{
    //public float hitForce = 1669;
    //public ForceMode forceMode = ForceMode.Acceleration;

public override string animToolName { get; } = TechType.Scanner.AsString(true);
public override bool OnRightHandDown()
    {
        Cut();
        return true;
    }
/*public override bool OnRightHandHeld()
    {
        Cut();
        return true;
    }*/
private void Cut()
    {
        OnToolUseAnim(Player.main.guiHand);
    }
public override void OnToolUseAnim(GUIHand hand)
    {
        base.OnToolUseAnim(hand);

        GameObject hitObj = null;
        Vector3 hitPosition = default;
        UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, attackDist, ref hitObj, ref hitPosition);
        if (!hitObj)
        {
            // Nothing is in our attack range. Exit method.
        //    return;
        }

        var liveMixin = hitObj.GetComponentInParent<LiveMixin>();
        var techTag = hitObj.GetComponentInParent<TechTag>().type;
        if (liveMixin && IsValidTarget(liveMixin) && liveMixin.health > 0)
        {
            TechType techType = techTag;
            var rigidbody = hitObj.GetComponentInParent<Rigidbody>();

            if (rigidbody)
            {
                if (CreatureList.Creatures.ContainsKey(techType)) {
                    //var techType = CreatureList.Creatures[classID];
                    CraftData.AddToInventory(TechType.Titanium);
                    //rigidbody.AddForce(MainCamera.camera.transform.forward * hitForce, forceMode);
                    return;
                }
                else
                {
                //    return;
                }
            }
        }
    }
}