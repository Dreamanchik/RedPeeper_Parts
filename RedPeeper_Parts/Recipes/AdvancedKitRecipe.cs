﻿using Nautilus.Crafting;
using Nautilus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdvancedKitlRecipe
{
    // Изменяем рецепт циклопа
    public static RecipeData AdvancedKitRecipeData = new RecipeData
    {
        craftAmount = 1,

        Ingredients = 
    {
        new CraftData.Ingredient(TechType.ComputerChip, 2),
        new CraftData.Ingredient(TechType.Quartz, 3),
        new CraftData.Ingredient(TechType.WiringKit, 2),
        new CraftData.Ingredient(TechType.Benzene, 2),
        new CraftData.Ingredient(TechType.Gold, 3)
    }
    };
}
