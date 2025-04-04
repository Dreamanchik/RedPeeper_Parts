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
            new CraftData.Ingredient(TechType.Titanium, 4),
            new CraftData.Ingredient(TechType.CopperWire, 1),
        }
        };
    }
}