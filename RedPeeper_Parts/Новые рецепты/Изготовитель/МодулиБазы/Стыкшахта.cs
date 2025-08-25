using Nautilus.Crafting;

public class РецептСтыковочнойШахты
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.TitaniumIngot, 1),
            new Ingredient(TechType.Lead, 4),
            new Ingredient(TechType.Lubricant, 2),
            new Ingredient(TechType.ComputerChip, 1),
            new Ingredient(TechType.WiringKit, 1),
        }
        };
    }
}