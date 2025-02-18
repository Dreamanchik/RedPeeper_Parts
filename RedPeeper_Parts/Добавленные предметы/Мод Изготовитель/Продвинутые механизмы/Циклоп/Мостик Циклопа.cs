using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class МостикЦиклопа
{
    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "AdvancedElectronics", "Cyclops", "CyclopsBridge.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_CyclopsBridge",
            "Мостик Циклопа",
            "Центральная рубка Циклопа. Позволяет отдавать команды о запуске двигателя, передвижении, активировать функционал модификаций, режим просмотра внешних камер и редактирования окраски."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 4));
        CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm);

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "72d0460c-1b50-416b-8a9d-58e415132d3d"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            obj.EnsureComponent<Pickupable>();
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(ДвухфакторныйИнициализатор.Info.TechType, 1),
            new Ingredient(TechType.MapRoomHUDChip, 1),
            new Ingredient(TechType.AdvancedWiringKit, 1),
            new Ingredient(TechType.Silicone, 4),
            new Ingredient(TechType.TitaniumIngot, 2),
            new Ingredient(TechType.Lead, 4)
            ))

            .WithCraftingTime(100f);
        _prefab.SetPdaGroupCategory(TechGroup.Cyclops, TechCategory.Cyclops); // КПК

        _prefab.Register(); // Регистрация
    }
}