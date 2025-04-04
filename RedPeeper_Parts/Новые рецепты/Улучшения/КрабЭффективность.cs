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
                new CraftData.Ingredient(TechType.TitaniumIngot, 1),
                new CraftData.Ingredient(TechType.Nickel, 4),
                new CraftData.Ingredient(TechType.Sulphur, 6),
                new Ingredient(АмоГель.Info.TechType, 2),
            }
        };
    }
}
