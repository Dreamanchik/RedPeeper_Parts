using Nautilus.Crafting;
using static CraftData;

public class РецептЭлектрообороны
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(TechType.Gold, 4),
                new Ingredient(ЭлТкань.Info.TechType, 1),
                new Ingredient(TechType.ShellGrassSeed, 2)
            }
        };
    }
}
