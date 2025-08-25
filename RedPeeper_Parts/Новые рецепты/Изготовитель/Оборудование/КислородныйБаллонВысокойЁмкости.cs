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
            new Ingredient(TechType.Tank, 1),
            new Ingredient(TechType.Lithium, 4),
            new Ingredient(TechType.ComputerChip, 1),
            new Ingredient(TechType.SnakeMushroomSpore, 4),
        }
        };
    }
}
