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
            new CraftData.Ingredient(TechType.ComputerChip, 2),
            new CraftData.Ingredient(TechType.Quartz, 3),
            new CraftData.Ingredient(TechType.WiringKit, 2),
            new CraftData.Ingredient(TechType.Polyaniline, 1),
            new CraftData.Ingredient(TechType.Benzene, 2),
            new CraftData.Ingredient(TechType.Gold, 3)
        }
        };
    }
}