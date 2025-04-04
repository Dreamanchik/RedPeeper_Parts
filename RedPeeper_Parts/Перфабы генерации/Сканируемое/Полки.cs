using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Handlers;
using Nautilus.Utility;
using RedPeeper_Parts;
using System.IO;
using System.Reflection;
using UnityEngine;

public class ScannableShelvesCollider
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_ScannableShelvesCollider", 
        "Промышленный стеллаж", 
        "У тебя не должно быть доступа к этому..."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string texturePath = Path.Combine(modFolder, "Assets", "World", "Drillable", "DrillableReefbackRock_texture.png"); //  <-- Путь к текстуре
    public static string specPath = Path.Combine(modFolder, "Assets", "World", "Drillable", "DrillableReefbackRock_spec.png"); //  <-- Путь к текстуре
    public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static Texture2D Specular = ImageUtils.LoadTextureFromFile(specPath);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        _prefab.SetGameObject(CreatePrefab);

        _prefab.Register();
    }
    private static GameObject CreatePrefab()
    {
        GameObject _obj = new GameObject();
        // The classID is the same as the one we put into the PrefabInfo.WithTechType up above
        // The LargeWorldEntity.CellLevel determines how far away the object will be loaded from the player
        PrefabUtils.AddBasicComponents(_obj, Info.ClassID, Info.TechType, LargeWorldEntity.CellLevel.Medium);

        // Makes the GameObject have the correct shaders
        // You can use the optional inputs here to change the look of your object
        MaterialUtils.ApplySNShaders(_obj);

        PDAHandler.AddCustomScannerEntry(Info.TechType, ПромышленныйСтеллаж.Info.TechType, true, 5, 10f, false); // Айди, что открывает, фрагмент ли, сколько нужно для открытия, время сканирования, пропадает ли. Ты ещё можешь привязать кастомный лог КПК, как в древнем захронении
        // PDAHandler.AddCustomScannerEntry(Info.TechType, АварийныйКонтейнер.Info.TechType, true, 2, 3f, false);
        // PDAHandler.AddCustomScannerEntry(Info.TechType, НапольныйШкаф.Info.TechType, true, 4, 3f, false);
        BoxCollider scanCollider = _obj.EnsureComponent<BoxCollider>();
        //BoxCollider findScanCollider = _obj.GetComponent<BoxCollider>();
        //findScanCollider.extents.Set(3.8f, 5f, 1.5f);



        //(3.8f, 5f, 1.5f);

        // Return the GameObject with all the components added
        return _obj;
    }
}

