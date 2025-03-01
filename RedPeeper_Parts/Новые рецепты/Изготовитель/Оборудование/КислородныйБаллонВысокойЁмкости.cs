using Nautilus.Crafting;

public class РецептКислородногоБаллонаВысокойЁмкости
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Tank, 1),
            new CraftData.Ingredient(TechType.Lithium, 4),
            new CraftData.Ingredient(TechType.ComputerChip, 1),
            new CraftData.Ingredient(TechType.SnakeMushroomSpore, 4),
        }
        };
    }
}
