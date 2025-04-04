using Nautilus.Crafting;
using static CraftData;

public class РецептСолнечнойЗарядки
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(СолнечнаяЯчейка.Info.TechType, 1),
            }
        };
    }
}
