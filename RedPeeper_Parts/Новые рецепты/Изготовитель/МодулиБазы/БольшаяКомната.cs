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
            new CraftData.Ingredient(TechType.PlasteelIngot, 2),
            new CraftData.Ingredient(TechType.Lead, 5),
            new CraftData.Ingredient(СывороткаПлоти.Info.TechType)
        }
        };
    }
}
