using Nautilus.Crafting;
using static CraftData;

public class РецептСтроителя
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Silicone, 2),
            new CraftData.Ingredient(TechType.Titanium, 2),
            new CraftData.Ingredient(TechType.WiringKit, 1),
            new Ingredient(ДвухфакторныйИнициализатор.Info.TechType, 1),
        }
        };
    }
}
