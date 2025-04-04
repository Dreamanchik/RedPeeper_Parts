using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Utility;
using static CraftData;
using System.Reflection;
using UnityEngine;
using Nautilus.Assets.Gadgets;
using System.IO;

public class УпаковочнаяТкань : IBattery
{
    public float charge { get; set; }
    public float capacity { get; set; }

    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Synthesis", "PackingFabric.png");

    public static string texturePath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "TwoFactorProcessor_texture.png");
    public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_PackingFabric",
            "Упаковочная ткань",
            "Стерильная среда, синтезированная из структуры мембраны. Подходит для сбора образцов ДНК. Положите в свободный слот ДНК-Передатчика для синтеза образцов ДНК. Одноразовая."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Battery); // Перфаб
        _obj.ModifyPrefab += obj =>
        {

            Battery batteryComponent = obj.GetComponent<Battery>();
            batteryComponent._capacity = 1;
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Bleach),
            new Ingredient(Мембрана.Info.TechType, 2)

            ))
            .WithCraftingTime(3f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.BasicMaterials); // КПК


        _prefab.SetUnlock(Мембрана.Info.TechType);
        _prefab.SetUnlock(Мембрана2.Info.TechType);
        _prefab.Register(); // Регистрация
    }

    public string GetChargeValueText()
    {
        //throw new System.NotImplementedException();
        throw new();
    }
}