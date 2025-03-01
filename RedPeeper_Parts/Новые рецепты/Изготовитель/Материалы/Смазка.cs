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
            new CraftData.Ingredient(TechType.BluePalmSeed, 2),
            new CraftData.Ingredient(TechType.CreepvineSeedCluster, 1),
            new CraftData.Ingredient(TechType.AcidMushroom, 2),
        }
        };
    }
}
