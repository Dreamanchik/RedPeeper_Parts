using Nautilus.Crafting;
using static CraftData;

public class РецептРеактивныхУскорителей
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(TechType.TitaniumIngot, 1),
                new Ingredient(TechType.Nickel, 4),
                new Ingredient(TechType.Sulphur, 6),
                new Ingredient(АмоГель.Info.TechType, 2),
            }
        };
    }
}
