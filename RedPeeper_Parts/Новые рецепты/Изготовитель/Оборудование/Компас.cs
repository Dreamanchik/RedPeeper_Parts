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
            new Ingredient(TechType.WiringKit, 1),
            new Ingredient(TechType.Magnetite, 2),
        }
        };
    }
}
