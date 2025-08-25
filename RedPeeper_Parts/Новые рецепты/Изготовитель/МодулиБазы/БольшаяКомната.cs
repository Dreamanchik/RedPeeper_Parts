using Nautilus.Crafting;

public class РецептБольшойКомнаты
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.PlasteelIngot, 2),
            new Ingredient(TechType.Lead, 5),
            new Ingredient(СывороткаПлоти.Info.TechType, 1)
        }
        };
    }
}
