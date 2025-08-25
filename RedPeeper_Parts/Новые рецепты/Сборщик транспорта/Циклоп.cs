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
            new Ingredient(ДвигательЦиклопа.Info.TechType, 1),
            new Ingredient(МостикЦиклопа.Info.TechType, 1),
            new Ingredient(КорпусЦиклопа.Info.TechType, 1)
        }
        };
    }
}
