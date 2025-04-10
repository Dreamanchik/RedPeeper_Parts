﻿using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class МеднаяБатарейка : IBattery
{
    public float charge {  get; set; }
    public float capacity { get; set; }

    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Electronics", "CopperBattery.png");

    // public static string texturePath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "TwoFactorProcessor_texture.png");
    // public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_CopperBattery",
            "Медная батарея",
            "Портативный и мобильный аккумулятор, позволяющий запитать персональные инструменты. Пониженная энергоёмкость."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));
            //.WithSizeInInventory(new Vector2int(1, 1));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Battery); // Перфаб
        _obj.ModifyPrefab += obj =>
        {

            Battery batteryComponent = obj.GetComponent<Battery>();
            batteryComponent._capacity = 60;
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Titanium),
            new Ingredient(TechType.Copper),
            new Ingredient(НакопительныйКонцентрат.Info.TechType)

            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "BasicMaterials")
            .WithCraftingTime(5f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics); // КПК

        //_prefab.SetUnlock(TechType.MercuryOre);
        _prefab.Register(); // Регистрация
    }

    public string GetChargeValueText()
    {
        //throw new System.NotImplementedException();
        throw new();
    }
}