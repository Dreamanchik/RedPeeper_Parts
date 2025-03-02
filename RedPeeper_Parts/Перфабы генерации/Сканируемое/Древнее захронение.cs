using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Handlers;
using Nautilus.Utility;
using RedPeeper_Parts;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class AncientSandworm
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_AncientSandworm", 
        "Захронение", 
        "Древнее захронение."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        _prefab.SetGameObject(CreatePrefab());

        _prefab.Register();
    }
    private static GameObject CreatePrefab()
    {
        GameObject _obj = Plugin.AssetBundle.LoadAsset<GameObject>("horrorcrab");

        // The classID is the same as the one we put into the PrefabInfo.WithTechType up above
        // The LargeWorldEntity.CellLevel determines how far away the object will be loaded from the player
        PrefabUtils.AddBasicComponents(_obj, Info.ClassID, Info.TechType, LargeWorldEntity.CellLevel.Medium);

        // Makes the GameObject have the correct shaders
        // You can use the optional inputs here to change the look of your object
        MaterialUtils.ApplySNShaders(_obj);


        PDAHandler.AddCustomScannerEntry(Info.TechType, 10f, false, "SandwormPDA"); //Течтайп, сколько секунд сканировать, уничтожать ли при сканировании, айди лога

        // Return the GameObject with all the components added
        return _obj;
    }
}
public class AncientSandwormPDA
{
    //public static StoryGoal RPPdaTest { get; private set; }
    public static void Register()
    {
        PDAHandler.AddEncyclopediaEntry(
        "SandwormPDA",        // Айди
        "Lifeforms/Fauna",  // Путь (https://subnauticamodding.github.io/Nautilus/tutorials/databank-entries.html#creating-an-entry-path)
        "Sandworm",          // Название
        "Ну оооон типо огроооомный даааааа"       // Описание
        );
    }
}

