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
                new CraftData.Ingredient(TechType.PlasteelIngot, 1),
                new CraftData.Ingredient(TechType.Silicone, 6),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(АмоГель.Info.TechType, 1),
            }
        };
    }
}