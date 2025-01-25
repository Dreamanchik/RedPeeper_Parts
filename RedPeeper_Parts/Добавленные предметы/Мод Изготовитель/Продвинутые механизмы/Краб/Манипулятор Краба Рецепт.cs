using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public class РецептМанипулятораКраба
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.PlasteelIngot, 1),
            new Ingredient(TechType.WiringKit, 2),
            new Ingredient(TechType.Aerogel, 1),
            new Ingredient(TechType.CopperWire, 2),
            new Ingredient(TechType.Titanium, 3)
        }
        };
    }
}
