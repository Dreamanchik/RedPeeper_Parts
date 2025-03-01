using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

public class GrassyWreckCopy
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_GrassyWreckCopy", 
        "Обломок", 
        "Обломок Авроры."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "ad1e0255-d577-43ac-afa6-4cf17e08a067");
        _clone.ModifyPrefab += obj =>
        {
            // Удаляю лут (страшно)
            GameObject slots = obj.transform.Find("Slots").gameObject;
            GameObject.Destroy(slots);

            // Перекидываю спавн наружних железок назад в иерархии, чтобы потом сделать бэкфлип
            GameObject wreckHull1 = obj.transform.Find("ExteriorEntities/ExplorableWreckHull01(Placeholder)").gameObject;
            wreckHull1.transform.parent = obj.transform;
            GameObject wreckHull2 = obj.transform.Find("ExteriorEntities/ExplorableWreckHull02(Placeholder)").gameObject;
            wreckHull2.transform.parent = obj.transform;

            // Перекидываю спавн дверей, чтобы потом сделать бэкфлип
            GameObject door1 = obj.transform.Find("Doors/Wrecks_Starship_doors_sealed(Placeholder)").gameObject;
            door1.name = "Door1";
            door1.transform.parent = obj.transform;

            // Делаю бэкфлип
            GameObject exteriorEntities = obj.transform.Find("ExteriorEntities").gameObject;
            GameObject.Destroy(exteriorEntities);
            GameObject interiorEntities = obj.transform.Find("InterioEntities").gameObject;
            GameObject.Destroy(interiorEntities);
            GameObject doors = obj.transform.Find("Doors").gameObject;
            GameObject.Destroy(doors);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

