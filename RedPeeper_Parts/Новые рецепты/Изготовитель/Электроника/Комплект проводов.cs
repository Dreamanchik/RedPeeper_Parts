using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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