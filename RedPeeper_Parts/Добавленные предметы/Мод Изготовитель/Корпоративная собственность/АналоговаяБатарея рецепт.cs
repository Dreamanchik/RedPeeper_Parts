using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public class РецептАнаговойБатареи
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.UraniniteCrystal, 2),
            new Ingredient(TechType.Titanium, 2),
            new Ingredient(TechType.CopperWire)
        }
        };
    }
}
