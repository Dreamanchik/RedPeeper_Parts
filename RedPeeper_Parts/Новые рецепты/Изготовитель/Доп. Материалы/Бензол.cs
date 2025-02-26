﻿using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class РецептБензола
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.BloodOil, 3),
            new CraftData.Ingredient(TechType.RedRollPlantSeed),
            new CraftData.Ingredient(TechType.HangingFruit)
        }
        };
    }
}
