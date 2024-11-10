using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;
using UnityEngine.ParticleSystemJobs;
using UnityEngine;
using Nautilus.Extensions;
using System.Runtime.InteropServices.ComTypes;
using HarmonyLib;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System;
using ICSharpCode.SharpZipLib.Core;

public class ScannerTest
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "StorageConcentrate.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "ScannerTest",
            "Тест сканнера",
            "Among us"
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(1, 2)); // РАЗМЕР В ИНВЕНТАРЕ
        //CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Scanner); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПА
        _obj.ModifyPrefab += obj =>
        {
            var scanner = obj.GetComponent<ScannerTool>();
            var scannerTest = obj.AddComponent<ScannerTestData>().CopyComponent(scanner);
            UnityEngine.Object.DestroyImmediate(scanner);
            
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.CopperWire, 1),
            new Ingredient(TechType.AcidMushroom, 4)
            //    РЕЦЕПТ КОНЕЦ
            ))
            .WithFabricatorType(CraftTree.Type.Fabricator) // В 2.0 отказались от вкладок в мод станции, я не знаю зачем
            .WithStepsToFabricatorTab("Resources", "AdvancedMaterials")
            .WithCraftingTime(3f); // ВРЕМЯ КРАФТА
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.AdvancedMaterials); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}
public class ScannerTestData : ScannerTool
{   
    
    /*public float hitForce = 1669;
    public ForceMode forceMode = ForceMode.Acceleration;
    public float attackDist = 3f;

    public override string animToolName { get; } = TechType.Scanner.AsString(true);

    public override void OnToolUseAnim(GUIHand hand)
    {
        base.OnToolUseAnim(hand);

        GameObject hitObj = null;
        Vector3 hitPosition = default;
        UWE.Utils.TraceFPSTargetPosition(Player.main.gameObject, attackDist, ref hitObj, ref hitPosition);
        if (!hitObj)
        {
            // Nothing is in our attack range. Exit method.
            return;
        }

        var liveMixin = hitObj.GetComponentInParent<LiveMixin>();
        if (liveMixin && IsValidTarget(liveMixin))
        {
            var rigidbody = hitObj.GetComponentInParent<Rigidbody>();

            if (rigidbody)
            {
                rigidbody.AddForce(MainCamera.camera.transform.forward * hitForce, forceMode);
            }
        }
    }*/
}