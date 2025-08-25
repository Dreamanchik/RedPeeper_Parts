using Nautilus.Crafting;

public class РецептСмазки
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.BluePalmSeed, 2),
            new Ingredient(TechType.CreepvineSeedCluster, 1),
            new Ingredient(TechType.AcidMushroom, 2),
        }
        };
    }
}
