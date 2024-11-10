using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AerogelRecipe
{
    // Изменяем рецепт циклопа
    public static RecipeData AerogelRecipeData = new RecipeData
    {
        craftAmount = 1,

        Ingredients = 
    {
        new CraftData.Ingredient(TechType.JellyPlant, 5),
        new CraftData.Ingredient(TechType.AluminumOxide, 2),
        new CraftData.Ingredient(TechType.SeaCrownSeed, 2),
        new CraftData.Ingredient(TechType.Quartz, 2)
    }
    };
}

