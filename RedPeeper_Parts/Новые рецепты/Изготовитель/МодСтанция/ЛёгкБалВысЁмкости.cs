using Nautilus.Crafting;
using static CraftData;

public class РецептЛёгкогоБаллонаВысокойЁмкости
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.DoubleTank, 1),
            new Ingredient(TechType.TitaniumIngot, 1),
            new Ingredient(КомпДавл.Info.TechType, 1),
        }
        };
    }
}
