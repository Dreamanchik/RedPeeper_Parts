using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public class РецептЯчейка
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(НакопительныйКонцентрат.Info.TechType),
            new Ingredient(TechType.CopperWire, 1),
            new Ingredient(TechType.Titanium, 2),
            new Ingredient(TechType.WiringKit, 1)
        }
        };
    }
}
