using Nautilus.Crafting;

public class РецептКомпаса
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.WiringKit, 1),
            new CraftData.Ingredient(TechType.Magnetite, 2),
        }
        };
    }
}
