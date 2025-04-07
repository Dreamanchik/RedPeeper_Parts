﻿using Nautilus.Crafting;

public class РецептОгнетушителя
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Titanium, 1),
            new CraftData.Ingredient(TechType.CoralChunk, 2),
        }
        };
    }
}
