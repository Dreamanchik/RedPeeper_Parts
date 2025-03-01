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
            new CraftData.Ingredient(TechType.BloodOil, 3),
            new CraftData.Ingredient(TechType.RedRollPlantSeed),
            new CraftData.Ingredient(TechType.HangingFruit)
        }
        };
    }
}
