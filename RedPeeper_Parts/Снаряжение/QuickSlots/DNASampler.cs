using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CraftData;
using System.IO;
using Nautilus.Assets.Gadgets;
using UnityEngine;

public class DNASampler
{
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Fabricator", "Electronics", "SolarCell.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "DNASampler",
            "ДНК Передатчик",
            "А тебя это ебать не должно БОЛЬШИЕ ГОРОДА"
            )
            .WithSizeInInventory(new Vector2int(2, 2))
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Scanner); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            ScannerTool pdaScanner = obj.GetComponent<ScannerTool>();
            GameObject.Destroy(pdaScanner);
            obj.EnsureComponent<DNASamplerLogic>();
            DNASamplerLogic dnaSamplerLogic = obj.GetComponent<DNASamplerLogic>();
            dnaSamplerLogic.mainCollider = obj.transform.Find("collision").gameObject.GetComponent<BoxCollider>();
            dnaSamplerLogic.hasAnimations = true;
            dnaSamplerLogic.socket = PlayerTool.Socket.RightHand;
            dnaSamplerLogic.ikAimLeftArm = false;
            dnaSamplerLogic.ikAimRightArm = true;
        };
            _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Titanium)

            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "Electronics")
            .WithCraftingTime(10f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics); // КПК
        _prefab.SetEquipment(EquipmentType.Hand).WithQuickSlotType(QuickSlotType.Selectable);

        _prefab.Register(); // Регистрация
    }
}

