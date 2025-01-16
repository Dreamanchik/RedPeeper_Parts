using HarmonyLib;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers;
using Nautilus.Utility;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using static CraftData;

public class МодифицированныйИзготовитель
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "StorageConcentrate.png");
    public static void Register()
    {
        // Создаём префаб
        CustomPrefab customFab = new CustomPrefab(
            "RedPeeper_Modified_Fabricator",
            "Модифицированный изготовитель",
            "G"
            );

        // Делаем из него фабрикатор
        customFab.CreateFabricator(out CraftTree.Type treeType);
        CraftTreeHandler.AddTabNode(treeType, "ShitsNGiggles", "Crap", ImageUtils.LoadSpriteFromFile(iconPath));
        CraftTreeHandler.AddCraftingNode(treeType, Герметик.Info.TechType);
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
}
