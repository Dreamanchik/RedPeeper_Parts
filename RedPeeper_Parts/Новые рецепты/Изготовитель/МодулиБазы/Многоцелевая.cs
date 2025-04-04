using Nautilus.Crafting;

public class РецептМногоцелевойКомнаты
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.TitaniumIngot, 1),
            new CraftData.Ingredient(TechType.Lead, 3),
        }
        };
    }
}
