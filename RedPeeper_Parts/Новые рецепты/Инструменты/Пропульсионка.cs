using Nautilus.Crafting;
using static CraftData;

public class РецептПропульсионнойПушки
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Silicone, 1),
            new CraftData.Ingredient(TechType.Titanium, 2),
            new Ingredient(ПространственныйПроцессор.Info.TechType, 1),
        }
        };
    }
}
