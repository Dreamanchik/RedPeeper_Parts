using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;
using System.Reflection;
using System.IO;

public static class АварийныйКонтейнер
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Lifepods", "Lifepod12.png");
    public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("RP_EmergencyCrate", "Аварийный контейнер", "Небольшое хранилище, позволяющее вместить небольшое количество припасов для выживания. Оснащён влагозащитой.")
        .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

    public static void Register()
    {
        float PlaceDistance = 5;
        float MinPlaceDistance = 1;
        float MaxPlaceDistance = 10;
        CustomPrefab prefab = new CustomPrefab(Info);
        CloneTemplate clone = new CloneTemplate(Info, "3bc7707a-8525-4846-81ff-3ac0713efa10");

        clone.ModifyPrefab += obj =>
        {
            ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

            GameObject gameObject = obj.transform.Find("Crate_treasure_chest").gameObject;

            Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject);
            constructable.placeDefaultDistance = PlaceDistance;
            constructable.placeMinDistance = MinPlaceDistance;
            constructable.placeMaxDistance = MaxPlaceDistance;
            constructable.rotationEnabled = true;

            StorageContainer storageContainer = obj.EnsureComponent<StorageContainer>();
            storageContainer.width = 3;
            storageContainer.height = 2;

            GameObject storageRoot = new GameObject();
            storageRoot.transform.parent = obj.transform;
            storageRoot.name = "StorageRoot";
            ChildObjectIdentifier childObjectIdentifier = storageRoot.EnsureComponent<ChildObjectIdentifier>();
            storageContainer.storageRoot = childObjectIdentifier;

            SupplyCrate supplyCrate = obj.GetComponent<SupplyCrate>();
            Object.Destroy(supplyCrate);
            GameObject signal = obj.transform.Find("Signal(Placeholder)").gameObject;
            Object.Destroy(signal);
        };

        prefab.SetGameObject(clone);
        prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

        prefab.SetRecipe(new RecipeData(
            new Ingredient(TechType.Titanium, 3), 
            new Ingredient(TechType.Glass, 1)
            ));

        prefab.Register();
    }
}
