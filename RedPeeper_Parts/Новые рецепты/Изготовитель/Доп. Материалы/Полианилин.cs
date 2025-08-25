using Nautilus.Crafting;

public class РецептПолианилина
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.HydrochloricAcid, 2),
            new Ingredient(TechType.Gold, 3),
            new Ingredient(TechType.Silver, 2)
        }
        };
    }
}