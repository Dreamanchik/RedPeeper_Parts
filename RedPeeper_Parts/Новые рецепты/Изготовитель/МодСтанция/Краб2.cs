using Nautilus.Crafting;
using static CraftData;

public class РецептГлубиныПогруженияКостюмаКРАБ2
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.ExoHullModule1, 1),
            new CraftData.Ingredient(TechType.PlasteelIngot, 1),
            new CraftData.Ingredient(TechType.Benzene, 2),
            new CraftData.Ingredient(TechType.Kyanite, 4),
            new CraftData.Ingredient(TechType.AramidFibers, 1),
            new Ingredient(КомпДавл.Info.TechType, 1),
            new Ingredient(СывороткаПлоти.Info.TechType, 1),
        }
        };
    }
}