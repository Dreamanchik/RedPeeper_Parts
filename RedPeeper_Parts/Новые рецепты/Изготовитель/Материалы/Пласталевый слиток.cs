using Nautilus.Crafting;
public class РецептПласталевогоСлитка
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.TitaniumIngot, 1),
            new CraftData.Ingredient(TechType.Lithium, 4),
            new CraftData.Ingredient(TechType.Diamond, 2),
        }
        };
    }
}