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
            new Ingredient(TechType.TitaniumIngot, 1),
            new Ingredient(TechType.Lithium, 4),
            new Ingredient(TechType.Diamond, 2),
        }
        };
    }
}