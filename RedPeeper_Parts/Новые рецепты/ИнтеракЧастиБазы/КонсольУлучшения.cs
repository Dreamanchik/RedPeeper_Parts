using Nautilus.Crafting;
using static CraftData;

public class РецептКонсолиУлучшения
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(ДвухфакторныйИнициализатор.Info.TechType, 1),
            new Ingredient(TechType.Titanium, 4),
            new Ingredient(TechType.CopperWire, 1),
        }
        };
    }
}