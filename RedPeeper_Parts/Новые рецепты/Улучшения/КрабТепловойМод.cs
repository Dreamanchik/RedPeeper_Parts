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
                new CraftData.Ingredient(TechType.Polyaniline, 2),
                new CraftData.Ingredient(TechType.Kyanite, 4),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(БиоТерм.Info.TechType, 2),
            }
        };
    }
}
