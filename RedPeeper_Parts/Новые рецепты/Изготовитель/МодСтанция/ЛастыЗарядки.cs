using Nautilus.Crafting;
using static CraftData;

public class РецептЛастыЗарядки
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Fins, 1),
            new CraftData.Ingredient(TechType.AdvancedWiringKit, 1),
            new CraftData.Ingredient(TechType.AramidFibers, 2),
            new Ingredient(ЭлТкань.Info.TechType, 2),
        }
        };
    }
}