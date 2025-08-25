using Nautilus.Crafting;
using static CraftData;

public class РецептКрюковойРуки
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(TechType.PlasteelIngot, 1),
                new Ingredient(TechType.Silicone, 6),
                new Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(АмоГель.Info.TechType, 1),
            }
        };
    }
}