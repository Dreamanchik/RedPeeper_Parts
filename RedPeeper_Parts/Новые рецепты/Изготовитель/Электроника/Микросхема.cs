using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class РецептМикросхемы
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.WiringKit, 2),
            new CraftData.Ingredient(TechType.JeweledDiskPiece, 4),
            new CraftData.Ingredient(TechType.SpikePlantSeed, 2),
        }
        };
    }
}