using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class КорпусЦиклопа
{

    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "AdvancedElectronics", "Cyclops", "CyclopsHull.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_CyclopsHull",
            "Корпус Циклопа",
            "Проводящая электричество обшивка, позволяющая Циклопу подниматься и опускаться. Из-за особенности конструкции может легко повредится. Может менять окрас при соответствующей команде с мостика."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(6, 4));
        CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm);

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "0ba2de19-0f6e-4469-bf77-8c0f9db95875"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            obj.EnsureComponent<Pickupable>();
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.PlasteelIngot, 4),
            new Ingredient(TechType.AdvancedWiringKit, 1),
            new Ingredient(TechType.Aerogel, 2),
            new Ingredient(TechType.CopperWire, 4)

            ))
            .WithCraftingTime(150f);
        _prefab.SetUnlock(TechType.Cyclops);
        _prefab.SetPdaGroupCategory(TechGroup.Cyclops, TechCategory.Cyclops); // КПК

        _prefab.Register(); // Регистрация
    }
}