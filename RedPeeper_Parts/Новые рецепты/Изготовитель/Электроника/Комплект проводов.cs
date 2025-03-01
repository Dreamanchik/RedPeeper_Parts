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
            new CraftData.Ingredient(TechType.Silver, 4),
            new CraftData.Ingredient(TechType.CopperWire, 1),
            new CraftData.Ingredient(TechType.Silicone, 2),
            new CraftData.Ingredient(TechType.Gold, 2)
        }
        };
    }
}