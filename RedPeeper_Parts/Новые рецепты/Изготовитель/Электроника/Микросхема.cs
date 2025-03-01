using Nautilus.Crafting;

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