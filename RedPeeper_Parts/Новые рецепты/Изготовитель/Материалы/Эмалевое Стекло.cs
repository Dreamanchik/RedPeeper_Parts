using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class РецептЭмалевогоСтекла
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Glass, 2),
            new CraftData.Ingredient(TechType.Lead, 3),
            new CraftData.Ingredient(TechType.StalkerTooth, 1),
        }
        };
    }
}
