using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;
using System.Reflection;
using System.IO;

public static class ПромышленныйСтеллаж
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Lockers", "IndustrialRack.png");
    public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("RP_IndustrialRack", "Промышленный стеллаж", "Крупное автономное хранилище, вмещающее большое количество объектов. Используется в тяжёлой промышленности.")
        .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

    public static void Register()
    {
        float PlaceDistance = 5;
        float MinPlaceDistance = 1.5f;
        float MaxPlaceDistance = 10;
        CustomPrefab prefab = new CustomPrefab(Info);
        CloneTemplate clone = new CloneTemplate(Info, "33acd899-72fe-4a98-85f9-b6811974fbeb");

        clone.ModifyPrefab += obj =>
        {
            ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground;

            GameObject gameObject = obj.transform.Find("biodome_lab_shelf_01").gameObject;
            GameObject model = gameObject.transform.Find("biodome_lab_shelf_01").gameObject;

            Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject);
            constructable.placeDefaultDistance = PlaceDistance;
            constructable.placeMinDistance = MinPlaceDistance;
            constructable.placeMaxDistance = MaxPlaceDistance;
            constructable.rotationEnabled = true;

            obj.transform.localScale = new Vector3(0.5f, 0.45f, 0.5f);

            StorageContainer storageContainer = obj.EnsureComponent<StorageContainer>();
            storageContainer.width = 9;
            storageContainer.height = 8;

            GameObject storageRoot = new GameObject();
            storageRoot.transform.parent = obj.transform;
            storageRoot.name = "StorageRoot";
            ChildObjectIdentifier childObjectIdentifier = storageRoot.EnsureComponent<ChildObjectIdentifier>();
            storageContainer.storageRoot = childObjectIdentifier;

            MeshFilter MshFlt = model.GetComponent<MeshFilter>();
            Bounds bounds = MshFlt.sharedMesh.bounds;
            ConstructableBounds Coll = obj.AddComponent<ConstructableBounds>();
            Coll.bounds = new OrientedBounds(new Vector3(bounds.center.x, bounds.center.y + 1, bounds.center.z), new Quaternion(0 ,0 ,0, 0), new Vector3(bounds.size.x / 2.5f, bounds.size.y / 2.5f, bounds.size.z / 2.5f));
        };
        prefab.SetGameObject(clone);
        prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

        prefab.SetRecipe(new RecipeData(
            new Ingredient(TechType.Titanium, 10), 
            new Ingredient(TechType.Lithium, 2)
            ));

        prefab.Register();
    }
}
