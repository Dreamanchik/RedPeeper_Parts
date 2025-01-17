using HarmonyLib;
using JetBrains.Annotations;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers;
using Nautilus.Utility;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using UnityEngine;
using static CraftData;

public class МодифицированныйИзготовитель
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "StorageConcentrate.png");

    public static string texturePath = Path.Combine(modFolder, "Assets", "Fabricators", "Modified Fabricator", "ModifiedFabricator_texture.png"); //  <-- Путь к текстуре
    public static Texture2D mainTexture = ImageUtils.LoadTextureFromFile(texturePath);

    public static string ComponentsPath = Path.Combine(modFolder, "Assets", "Fabricators", "Modified Fabricator", "Tabs", "RedPeeper_ModStation_Components.png");
    public static string ChemicalPath = Path.Combine(modFolder, "Assets", "Fabricators", "Modified Fabricator", "Tabs", "RedPeeper_ModStation_Chemical.png");
    public static string CorporateToolsPath = Path.Combine(modFolder, "Assets", "Fabricators", "Modified Fabricator", "Tabs", "RedPeeper_ModStation_CorporateTools.png");
    public static string AdvancedElectronicsPath = Path.Combine(modFolder, "Assets", "Fabricators", "Modified Fabricator", "Tabs", "RedPeeper_ModStation_AdvancedElectronics.png");
    public static void Register()
    {
        // Создаём префаб
        CustomPrefab customFab = new CustomPrefab(
            "RedPeeper_Modified_Fabricator",
            "Модифицированный изготовитель",
            "Самодельное устройство, повторяющее и расширяющее функционал стандартного изготовителя. Конструкция этого изготовителя нарушает принципы протокола корпоративной собственности, что может привести к нарушению юрисдикции Альтерры. Применять на свой страх и риск."
            );

        // Делаем из него фабрикатор
        customFab.CreateFabricator(out CraftTree.Type treeType);

        // Добавляем категории
        CraftTreeHandler.AddTabNode(treeType, "RedPeeper_ModStation_Components", "Компоненты", ImageUtils.LoadSpriteFromFile(ComponentsPath));
        CraftTreeHandler.AddTabNode(treeType, "RedPeeper_ModStation_Chemical", "Химикаты", ImageUtils.LoadSpriteFromFile(ChemicalPath));
        CraftTreeHandler.AddTabNode(treeType, "RedPeeper_ModStation_CorporateTools", "Корпоративные инструменты", ImageUtils.LoadSpriteFromFile(CorporateToolsPath));
        CraftTreeHandler.AddTabNode(treeType, "RedPeeper_ModStation_AdvancedElectronics", "Продвинутые механизмы", ImageUtils.LoadSpriteFromFile(AdvancedElectronicsPath));
        // Добавляем предметы
        //  Компоненты
        CraftTreeHandler.AddCraftingNode(treeType, TechType.AdvancedWiringKit, "RedPeeper_ModStation_Components");
        CraftTreeHandler.AddCraftingNode(treeType, ПлазменнаяЛинза.Info.TechType, "RedPeeper_ModStation_Components");
        CraftTreeHandler.AddCraftingNode(treeType, СолнечнаяЯчейка.Info.TechType, "RedPeeper_ModStation_Components");
        CraftTreeHandler.AddCraftingNode(treeType, ПространственныйПроцессор.Info.TechType, "RedPeeper_ModStation_Components");
        //  Химикаты
        CraftTreeHandler.AddCraftingNode(treeType, TechType.Benzene, "RedPeeper_ModStation_Chemical");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.Bleach, "RedPeeper_ModStation_Chemical");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.HydrochloricAcid, "RedPeeper_ModStation_Chemical");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.Polyaniline, "RedPeeper_ModStation_Chemical");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.Aerogel, "RedPeeper_ModStation_Chemical");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.AramidFibers, "RedPeeper_ModStation_Chemical");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.HatchingEnzymes, "RedPeeper_ModStation_Chemical");
        //  Корпоративные инструменты
        CraftTreeHandler.AddCraftingNode(treeType, TechType.StasisRifle, "RedPeeper_ModStation_CorporateTools");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.LaserCutter, "RedPeeper_ModStation_CorporateTools");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.Builder, "RedPeeper_ModStation_CorporateTools");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.PropulsionCannon, "RedPeeper_ModStation_CorporateTools");
        CraftTreeHandler.AddCraftingNode(treeType, TechType.CyclopsDecoy, "RedPeeper_ModStation_CorporateTools");
        //  Продвинутые механизмы
        CraftTreeHandler.AddCraftingNode(treeType, МанипуляторКраба.Info.TechType, "RedPeeper_ModStation_AdvancedElectronics");
        CraftTreeHandler.AddCraftingNode(treeType, НогаКраба.Info.TechType, "RedPeeper_ModStation_AdvancedElectronics");
        CraftTreeHandler.AddCraftingNode(treeType, ДвигательЦиклопа.Info.TechType, "RedPeeper_ModStation_AdvancedElectronics");
        CraftTreeHandler.AddCraftingNode(treeType, КорпусЦиклопа.Info.TechType, "RedPeeper_ModStation_AdvancedElectronics");
        CraftTreeHandler.AddCraftingNode(treeType, МостикЦиклопа.Info.TechType, "RedPeeper_ModStation_AdvancedElectronics");

        // Иконка
        customFab.Info.WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));
        // Создаём хрень с фабрикатором
        FabricatorTemplate fabPrefab = new FabricatorTemplate(customFab.Info, treeType)
        {
            FabricatorModel = FabricatorTemplate.Model.Workbench
        };
        customFab.SetGameObject(fabPrefab);

        // Рецепт
        RecipeData recipe = new RecipeData()
        {
            Ingredients =
            {
                // РЕЦЕПТ НАЧАЛО
                new Ingredient(TechType.Titanium, 1000)
                // РЕЦЕПТ КОНЕЦ
            }
        };
        customFab.SetRecipe(recipe);

        // Анлок
        customFab.SetUnlock(TechType.Titanium).WithPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

        customFab.Register();
    }
    public static void ModifyGameObject(GameObject gameObject)
    {
        SkinnedMeshRenderer mr = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        mr.material.mainTexture = mainTexture;
    }
}
