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
            new CraftData.Ingredient(TechType.TitaniumIngot, 1),
            new CraftData.Ingredient(TechType.Lead, 4),
            new CraftData.Ingredient(TechType.Lubricant, 2),
            new CraftData.Ingredient(TechType.ComputerChip, 1),
            new CraftData.Ingredient(TechType.WiringKit, 1),
        }
        };
    }
}