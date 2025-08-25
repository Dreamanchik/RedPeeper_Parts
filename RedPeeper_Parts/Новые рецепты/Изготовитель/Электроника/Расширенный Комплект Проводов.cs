using Nautilus.Crafting;

public class РецептРасширенногоКомплектаПроводов
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.ComputerChip, 2),
            new Ingredient(TechType.Quartz, 3),
            new Ingredient(TechType.WiringKit, 2),
            new Ingredient(TechType.Polyaniline, 1),
            new Ingredient(TechType.Benzene, 2),
            new Ingredient(TechType.Gold, 3)
        }
        };
    }
}