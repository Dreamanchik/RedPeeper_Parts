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
                new Ingredient(TechType.PlasteelIngot, 2),
                new Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(СывороткаПлоти.Info.TechType, 1),
                new Ingredient(TechType.Diamond, 4)
            }
        };
    }
}
