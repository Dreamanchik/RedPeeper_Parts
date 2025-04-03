using Nautilus.Crafting;
using static CraftData;

public class РецептКраба
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(МанипуляторКраба.Info.TechType, 2),
            new Ingredient(НогаКраба.Info.TechType, 2),
            new Ingredient(КомпДавл.Info.TechType, 1),
            new Ingredient(ДвухфакторныйИнициализатор.Info.TechType, 1),
            new CraftData.Ingredient(TechType.PlasteelIngot, 1),
            new CraftData.Ingredient(TechType.Nickel, 2),
        }
        };
    }
}
