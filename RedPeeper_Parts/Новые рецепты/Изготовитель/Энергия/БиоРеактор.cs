using Nautilus.Crafting;
using static CraftData;

public class РецептБиоРеактора
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(ПищФер.Info.TechType, 1),
            new CraftData.Ingredient(TechType.TitaniumIngot, 1),
            new CraftData.Ingredient(TechType.Lead, 1),
            new CraftData.Ingredient(TechType.Lubricant, 2),
            new CraftData.Ingredient(TechType.WiringKit, 1),
        }
        };
    }
}
