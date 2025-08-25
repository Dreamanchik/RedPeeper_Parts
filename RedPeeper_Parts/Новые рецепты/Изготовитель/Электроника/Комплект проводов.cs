using Nautilus.Crafting;

public class РецептКомплектаПроводов
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 2,

            Ingredients =
        {
            new Ingredient(TechType.Silver, 4),
            new Ingredient(TechType.CopperWire, 1),
            new Ingredient(TechType.Silicone, 2),
            new Ingredient(TechType.Gold, 2)
        }
        };
    }
}