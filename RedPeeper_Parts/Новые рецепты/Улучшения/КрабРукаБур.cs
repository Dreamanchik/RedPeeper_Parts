using Nautilus.Crafting;
using static CraftData;

public class РецептБуровойРуки
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new CraftData.Ingredient(TechType.PlasteelIngot, 2),
                new CraftData.Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(СывороткаПлоти.Info.TechType, 1),
                new CraftData.Ingredient(TechType.Diamond, 4)
            }
        };
    }
}
