using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PolyanilineRecipe
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.HydrochloricAcid, 2),
            new CraftData.Ingredient(TechType.Gold, 3),
            new CraftData.Ingredient(TechType.Silver, 2)
        }
        };
    }
}