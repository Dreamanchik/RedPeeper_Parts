using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;
using Nautilus.Extensions;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

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
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));
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
        _prefab.SetEquipment(EquipmentType.Hand);
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
    public override string animToolName { get; } = TechType.Scanner.AsString(true);
    [HarmonyPatch(typeof(PDAScanner))]
    public static float MultiplyProgress(float progress)
    {
        return progress * (1.0f / 10);
    }
    [HarmonyPatch(nameof(PDAScanner.Scan))]
    [HarmonyTranspiler]
    static IEnumerable<CodeInstruction> ScanTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(instructions)
            .MatchForward(false, new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(NoCostConsoleCommand), "get_fastScanCheat")))
            .Advance(10)
            .Insert(Transpilers.EmitDelegate<Func<float, float>>(MultiplyProgress))
            .InstructionEnumeration();
    }
}