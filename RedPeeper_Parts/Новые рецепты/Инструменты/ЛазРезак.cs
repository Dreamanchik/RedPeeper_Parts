using Nautilus.Crafting;
using static CraftData;

public class РецептЛазерногоРезака
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Silicone, 3),
            new CraftData.Ingredient(TechType.Titanium, 2),
            new Ingredient(ПлазменнаяЛинза.Info.TechType, 1),
        }
        };
    }
}
