using Nautilus.Crafting;
using static CraftData;

public class РецептУлучшенияЭнергии
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new CraftData.Ingredient(TechType.AluminumOxide, 2),
                new CraftData.Ingredient(TechType.UraniniteCrystal, 1),
                new Ingredient(АмоГель.Info.TechType, 1),
            }
        };
    }
}
