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
            new CraftData.Ingredient(TechType.HydrochloricAcid, 2),
            new CraftData.Ingredient(TechType.Gold, 3),
            new CraftData.Ingredient(TechType.Silver, 2)
        }
        };
    }
}