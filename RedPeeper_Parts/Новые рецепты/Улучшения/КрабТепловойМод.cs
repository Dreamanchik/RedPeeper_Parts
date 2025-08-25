using Nautilus.Crafting;
using static CraftData;

public class РецептТермоРеактора
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(TechType.Polyaniline, 2),
                new Ingredient(TechType.Kyanite, 4),
                new Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(БиоТерм.Info.TechType, 2),
            }
        };
    }
}
