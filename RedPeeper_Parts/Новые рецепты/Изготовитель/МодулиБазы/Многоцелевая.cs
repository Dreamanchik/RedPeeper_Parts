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
            new Ingredient(TechType.TitaniumIngot, 1),
            new Ingredient(TechType.Lead, 3),
        }
        };
    }
}
