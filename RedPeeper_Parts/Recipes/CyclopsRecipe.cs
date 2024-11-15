using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CyclopsRecipe
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(RedPeeper_CyclopsEngine.Info.TechType),
            new CraftData.Ingredient(RedPeeper_CyclopsBridge.Info.TechType),
            new CraftData.Ingredient(RedPeeper_CyclopsHull.Info.TechType)
        }
        };
    }
}

