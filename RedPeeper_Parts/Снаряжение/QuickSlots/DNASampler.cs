using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Utility;
using System.Collections.Generic;
using System.Reflection;
using static CraftData;
using System.IO;
using Nautilus.Assets.Gadgets;
using UnityEngine;
using RedPeeper_Parts;
using System.Runtime.CompilerServices;

public static class DNASampler
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "CorporateTools", "DNASampler.png");
    public static PrefabInfo Info { get; private set; }

    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "DNASampler",
            "ДНК-передатчик",
            "Портативное устройство, позволяющее собирать уникальные образцы ДНК из внутренних оболочек инопланетной фауны. Использует мембраны в качестве упаковочного материала."
            )
            .WithSizeInInventory(new Vector2int(3, 2))
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        CustomPrefab _prefab = new CustomPrefab(Info);
        _prefab.SetGameObject(CreatePrefab());
        GadgetExtensions.SetEquipment(_prefab, EquipmentType.Hand);

        _prefab.SetRecipe(new RecipeData(

            new CraftData.Ingredient(TechType.Silicone, 3),
            new CraftData.Ingredient(TechType.Titanium, 2),
            new Ingredient(ДвухфакторныйИнициализатор.Info.TechType, 1)

        ))
            .WithCraftingTime(10f);
        _prefab.SetPdaGroupCategory(TechGroup.Personal, TechCategory.Equipment); // КПК
        _prefab.SetEquipment(EquipmentType.Hand).WithQuickSlotType(QuickSlotType.Selectable);
        _prefab.SetUnlock(DNASampler.Info.TechType);

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
        // Слот батарей

        PrefabUtils.AddBasicComponents(_obj, Info.ClassID, Info.TechType, LargeWorldEntity.CellLevel.Near);
        MaterialUtils.ApplySNShaders(_obj);

        List<TechType> compatibleBatteries = new List<TechType>(){УпаковочнаяТкань.Info.TechType};
        PrefabUtils.AddEnergyMixin(_obj, "BatterySlot", TechType.Battery, compatibleBatteries);
        Rigidbody rb = _obj.EnsureComponent<Rigidbody>();
        rb.mass = 8f;
        rb.useGravity = false;
        rb.isKinematic = true;
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

