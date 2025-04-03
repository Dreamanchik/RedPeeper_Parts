using Nautilus.Crafting;

public class РецептЛитийИоннойБатареи
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Battery, 1),
            new CraftData.Ingredient(TechType.Lithium, 4),
            new CraftData.Ingredient(TechType.Polyaniline, 1),
        }
        };
    }
}