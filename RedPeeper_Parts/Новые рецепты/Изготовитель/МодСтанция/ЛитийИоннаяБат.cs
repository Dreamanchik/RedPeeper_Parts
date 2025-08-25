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
            new Ingredient(TechType.Battery, 1),
            new Ingredient(TechType.Lithium, 4),
            new Ingredient(TechType.Polyaniline, 1),
        }
        };
    }
}