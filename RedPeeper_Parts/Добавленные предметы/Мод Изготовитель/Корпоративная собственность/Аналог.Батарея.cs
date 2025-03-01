using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class АналоговаяБатарея
{
   
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "CorporateTools", "AnalogBattery.png");

    public static void Register()



         {
            Info = PrefabInfo.WithTechType(
            "RP_AnalogBattery",
            "Аналоговая батарея",
            "Применяемая в тяжелой промышленности батарея, способная накапливать большое количество энергии за счёт уранового накопителя. Из-за особенности конструкции не может быть использована в качестве персональной батареи."
         )


            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2));

            var _prefab = new CustomPrefab(Info);
            var _obj = new CloneTemplate(Info, TechType.DepletedReactorRod); // Перфаб

        _obj.ModifyPrefab += obj =>
        {
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.UraniniteCrystal, 2),
            new Ingredient(TechType.Titanium, 2),
            new Ingredient(TechType.CopperWire)

            ))
            .WithCraftingTime(10f);

        _prefab.Register(); // Регистрация
    }
}



public class РецептАнаговойБатареи
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.UraniniteCrystal, 2),
            new Ingredient(TechType.Titanium, 2),
            new Ingredient(TechType.CopperWire)
        }
        };
    }
}
