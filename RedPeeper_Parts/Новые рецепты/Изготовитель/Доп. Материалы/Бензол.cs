using Nautilus.Crafting;

public class РецептБензола
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.BloodOil, 3),
            new Ingredient(TechType.RedRollPlantSeed, 1),
            new Ingredient(TechType.HangingFruit, 1)
        }
        };
    }
}
