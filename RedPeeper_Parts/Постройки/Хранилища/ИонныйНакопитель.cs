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

public static class ИонныйНакопитель
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Lifepods", "Lifepod12.png");
    public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("RP_PrecursorLocker", "Ионный накопитель", "Небольшое автономное хранилище, работающее на основе ионной энергии. Использует технологию ионной матрицы для преобразования объектов в ячейку данных, позволяя увеличить вместительность до возможного максимума.")
        .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

    public static void Register()
    {
        float PlaceDistance = 5;
        float MinPlaceDistance = 1;
        float MaxPlaceDistance = 10;
        CustomPrefab prefab = new CustomPrefab(Info);
        CloneTemplate clone = new CloneTemplate(Info, "dd3bf908-badb-4c8c-a195-eb50be09df63");

        clone.ModifyPrefab += obj =>
        {
            ConstructableFlags constructableFlags = ConstructableFlags.Inside | ConstructableFlags.Outside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

            GameObject gameObject = obj.transform.Find("Precursor_computer_terminal").gameObject;

            Constructable constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlags, gameObject);
            constructable.placeDefaultDistance = PlaceDistance;
            constructable.placeMinDistance = MinPlaceDistance;
            constructable.placeMaxDistance = MaxPlaceDistance;
            constructable.rotationEnabled = true;

            obj.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            StorageContainer storageContainer = obj.EnsureComponent<StorageContainer>();
            storageContainer.width = 9;
            storageContainer.height = 14;

            GameObject storageRoot = new GameObject();
            storageRoot.transform.parent = obj.transform;
            storageRoot.name = "StorageRoot";
            ChildObjectIdentifier childObjectIdentifier = storageRoot.EnsureComponent<ChildObjectIdentifier>();
            storageContainer.storageRoot = childObjectIdentifier;

            PrecursorComputerTerminal precursorComputerTerminal = obj.GetComponent<PrecursorComputerTerminal>();
            Object.Destroy(precursorComputerTerminal);
            StoryHandTarget storyHandTarget = obj.GetComponent<StoryHandTarget>();
            Object.Destroy(storyHandTarget);
            GameObject signal = obj.transform.Find("Precursor_computer_terminal_panel").gameObject;
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
