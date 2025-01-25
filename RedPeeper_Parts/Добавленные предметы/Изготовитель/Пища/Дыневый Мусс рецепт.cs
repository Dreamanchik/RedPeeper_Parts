using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public class РецептДыневыйМусс
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.BulboTreePiece, 1),
            new Ingredient(TechType.PurpleRattle, 3),
            new Ingredient(TechType.DisinfectedWater, 1),
            new Ingredient(TechType.MembrainTreeSeed, 1),
            new Ingredient(TechType.Melon, 1)
        }
        };
    }
}
