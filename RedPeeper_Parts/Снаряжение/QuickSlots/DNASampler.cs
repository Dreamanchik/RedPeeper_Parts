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
using Nautilus.Utility.MaterialModifiers;
using RedPeeper_Parts;
using System.Collections;
using System.Runtime.CompilerServices;
using Nautilus.Handlers;
using static GameObjectPoolPrefabMap;

public static class DNASampler
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

        CustomPrefab _prefab = new CustomPrefab(Info);
        //var _obj = new CloneTemplate(Info, TechType.Scanner); // Перфаб
        //GameObject _obj = Plugin.MyAssetBundle.LoadAsset<GameObject>("Transfuser_Prefab");
        _prefab.SetGameObject(CreatePrefab());
        GadgetExtensions.SetEquipment(_prefab, EquipmentType.Hand);

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
    private static GameObject CreatePrefab()
    {
        GameObject _obj = Plugin.AssetBundle.LoadAsset<GameObject>("Transfuser_Prefab");

        // Allows the object to be picked up
        _obj.AddComponent<Pickupable>();

        GameObject batterySlot = new GameObject();
        batterySlot.transform.parent = _obj.transform;
        batterySlot.name = "BatterySlot";
        ChildObjectIdentifier childObjectIdentifier = batterySlot.EnsureComponent<ChildObjectIdentifier>();

        PrefabUtils.AddBasicComponents(_obj, Info.ClassID, Info.TechType, LargeWorldEntity.CellLevel.Near);
        MaterialUtils.ApplySNShaders(_obj);

        List<TechType> compatibleBatteries = new List<TechType>(){TechType.Battery, TechType.PrecursorIonBattery};
        PrefabUtils.AddEnergyMixin(_obj, "BatterySlot", TechType.Battery, compatibleBatteries);
        Rigidbody rb = _obj.EnsureComponent<Rigidbody>();
        rb.mass = 8f;
        rb.useGravity = false;
        WorldForces wf = _obj.EnsureComponent<WorldForces>();
        wf.useRigidbody = rb;
        wf.aboveWaterDrag = 0.15f;
        wf.underwaterDrag = 0.3f;
        DNASamplerLogic dnaSamplerLogic = _obj.AddComponent<DNASamplerLogic>();
        dnaSamplerLogic.pickupable = _obj.EnsureComponent<Pickupable>();
        dnaSamplerLogic.mainCollider = _obj.GetComponent<Collider>();
        dnaSamplerLogic.hasAnimations = true;
        dnaSamplerLogic.socket = PlayerTool.Socket.RightHand;
        dnaSamplerLogic.ikAimLeftArm = false;
        dnaSamplerLogic.ikAimRightArm = true;
        dnaSamplerLogic.hasFirstUseAnimation = true;
        PrefabUtils.AddVFXFabricating(_obj, "Model", -0.15f, 0.2f, new Vector3(0.1f, 0.05f, 0f), 1f, new Vector3(90f, 0f, 0f));

        // Return the GameObject with all the components added
        return _obj;
    }
}

