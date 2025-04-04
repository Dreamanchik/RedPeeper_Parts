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
                new CraftData.Ingredient(TechType.Gold, 4),
                new Ingredient(ЭлТкань.Info.TechType, 1),
                new CraftData.Ingredient(TechType.ShellGrassSeed, 2)
            }
        };
    }
}
