using Nautilus.Crafting;

public class РецептЦиклопа
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(ДвигательЦиклопа.Info.TechType),
            new CraftData.Ingredient(МостикЦиклопа.Info.TechType),
            new CraftData.Ingredient(КорпусЦиклопа.Info.TechType)
        }
        };
    }
}
