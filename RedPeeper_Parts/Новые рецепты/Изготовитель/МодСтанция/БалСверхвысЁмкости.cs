using Nautilus.Crafting;
using static CraftData;

public class РецептБаллонаСверхвысокойЁмкости
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.DoubleTank, 1),
            new Ingredient(TechType.PlasteelIngot, 1),
            new Ingredient(TechType.AluminumOxide, 2),
            new Ingredient(TechType.Benzene, 1),
            new Ingredient(КомпДавл.Info.TechType, 1),
        }
        };
    }
}
