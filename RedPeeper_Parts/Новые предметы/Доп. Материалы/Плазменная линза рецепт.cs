using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public class РецептЛинзы
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(Мембрана.Info.TechType, 3),
            new Ingredient(TechType.Diamond, 5),
            new Ingredient(TechType.EnameledGlass, 2),
            new Ingredient(TechType.ComputerChip, 1)
        }
        };
    }
}
