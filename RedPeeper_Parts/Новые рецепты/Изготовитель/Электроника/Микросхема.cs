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
            new Ingredient(TechType.WiringKit, 2),
            new Ingredient(TechType.JeweledDiskPiece, 4),
            new Ingredient(TechType.SpikePlantSeed, 2),
        }
        };
    }
}