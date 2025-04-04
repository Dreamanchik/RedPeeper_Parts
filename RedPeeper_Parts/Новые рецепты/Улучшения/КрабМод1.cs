using Nautilus.Crafting;
using static CraftData;

public class РецептКорпусаЭкзокостюма1
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new CraftData.Ingredient(TechType.PlasteelIngot, 1),
                new CraftData.Ingredient(TechType.Nickel, 2),
                new CraftData.Ingredient(TechType.AluminumOxide, 4),
                new Ingredient(СывороткаПлоти.Info.TechType, 1),
                new Ingredient(КомпДавл.Info.TechType, 1),
            }
        };
    }
}
