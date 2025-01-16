using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public class РецептПроцессор
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.ComputerChip, 4),
            new Ingredient(TechType.ReactorRod, 2), 
            new Ingredient(TechType.CopperWire, 2),
            new Ingredient(TechType.PrecursorIonCrystal, 3),
            new Ingredient(TechType.AdvancedWiringKit, 1)
        }
        };
    }
}
