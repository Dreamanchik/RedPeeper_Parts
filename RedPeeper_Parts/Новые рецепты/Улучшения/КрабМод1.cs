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
                new Ingredient(TechType.PlasteelIngot, 1),
                new Ingredient(TechType.Nickel, 2),
                new Ingredient(TechType.AluminumOxide, 4),
                new Ingredient(СывороткаПлоти.Info.TechType, 1),
                new Ingredient(КомпДавл.Info.TechType, 1),
            }
        };
    }
}
