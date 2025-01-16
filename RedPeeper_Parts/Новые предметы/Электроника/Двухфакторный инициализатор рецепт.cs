using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public class РецептИнициализатор
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.CopperWire, 2),
            new Ingredient(TechType.ComputerChip, 1),
            new Ingredient(TechType.Magnetite, 3),
            new Ingredient(TechType.WiringKit, 1)
        }
        };
    }
}
