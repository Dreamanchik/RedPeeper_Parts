﻿using Nautilus.Crafting;

public class РецептБрониТранспорта
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.Lead, 2),
                new CraftData.Ingredient(TechType.Lithium, 2)
            }
        };
    }
}