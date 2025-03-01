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
            new CraftData.Ingredient(TechType.CreepvineSeedCluster, 6)
        }
        };
    }
}
