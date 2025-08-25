using Nautilus.Crafting;

public class РецептСиликоновойРезины
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.CreepvineSeedCluster, 3)
        }
        };
    }
}
