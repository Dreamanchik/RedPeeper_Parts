using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DoubleTankRecipe
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
