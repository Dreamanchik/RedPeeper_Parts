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
            new Ingredient(TechType.Magnetite, 5),
            new Ingredient(TechType.CopperWire, 3),
            new Ingredient(TechType.WiringKit),
            new Ingredient(TechType.ComputerChip)
        }
        };
    }
}
