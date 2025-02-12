using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class ДвигательЦиклопа
{
  
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "AdvancedElectronics", "Cyclops", "CyclopsEngine.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_CyclopsEngine",
            "Двигатель Циклопа",
            "Высокотехнологичный и громоздкий двигатель, способный вырабатывать огромную механическую тягу, позволяя Циклопу передвигаться. Имеет встроенную консоль модификации. Склонен к перегреву при слишком высокой нагрузке."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 4));
        CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm);

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "3c076458-505e-4683-90c1-34c1f7939a0f"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            obj.EnsureComponent<Pickupable>();
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.TitaniumIngot, 3),
            new Ingredient(TechType.Lubricant, 8),
            new Ingredient(TechType.ComputerChip, 3),
            new Ingredient(TechType.Silicone, 2),
            new Ingredient(TechType.PowerCell, 6)

            ))
            .WithCraftingTime(100f);
        _prefab.SetPdaGroupCategory(TechGroup.Cyclops, TechCategory.Cyclops); // КПК

        _prefab.Register(); // Регистрация
    }
}