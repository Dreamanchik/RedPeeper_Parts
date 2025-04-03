using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;
using System.Reflection;
using System.IO;

public static class НапольныйШкаф
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Lockers", "PersonalLocker.png");
    public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("RP_PersonalLocker", "Напольный шкаф", "Относительно небольшое напольное хранилище, предназначенное для хранения личных вещей.")
        .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

    public static void Register()
    {
        float PlaceDistance = 5;
        float MinPlaceDistance = 1;
        float MaxPlaceDistance = 10;
        CustomPrefab prefab = new CustomPrefab(Info);
        CloneTemplate clone = new CloneTemplate(Info, "cd34fecd-794c-4a0c-8012-dd81b77f2840");

        clone.ModifyPrefab += obj =>
        {
            ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground;

            GameObject gameObject = obj.transform.Find("submarine_locker_04").gameObject;

            Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject);
            constructable.placeDefaultDistance = PlaceDistance;
            constructable.placeMinDistance = MinPlaceDistance;
            constructable.placeMaxDistance = MaxPlaceDistance;
            constructable.rotationEnabled = true;

            StorageContainer storageContainer = obj.EnsureComponent<StorageContainer>();
            storageContainer.width = 6;
            storageContainer.height = 8;

            GameObject storageRoot = new GameObject();
            storageRoot.transform.parent = obj.transform;
            storageRoot.name = "StorageRoot";
            ChildObjectIdentifier childObjectIdentifier = storageRoot.EnsureComponent<ChildObjectIdentifier>();
            storageContainer.storageRoot = childObjectIdentifier;
        };

        prefab.SetGameObject(clone);
        prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

        prefab.SetRecipe(new RecipeData(
            new Ingredient(TechType.Titanium, 8), 
            new Ingredient(TechType.Lead, 2)
            ));

        prefab.Register();
    }
}
