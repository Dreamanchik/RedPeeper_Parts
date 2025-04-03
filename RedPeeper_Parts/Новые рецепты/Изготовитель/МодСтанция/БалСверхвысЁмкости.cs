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
            new CraftData.Ingredient(TechType.DoubleTank, 1),
            new CraftData.Ingredient(TechType.PlasteelIngot, 1),
            new CraftData.Ingredient(TechType.AluminumOxide, 2),
            new CraftData.Ingredient(TechType.Benzene, 1),
            new Ingredient(КомпДавл.Info.TechType, 1),
        }
        };
    }
}
