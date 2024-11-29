using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class РецептАптечки
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.FiberMesh, 2),
            new CraftData.Ingredient(TechType.Bleach, 1),
            new CraftData.Ingredient(TechType.JellyPlant, 1),
        }
        };
    }
}
