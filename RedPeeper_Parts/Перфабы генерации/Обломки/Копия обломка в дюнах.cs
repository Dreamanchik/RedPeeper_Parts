﻿using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DunesWreckCopy
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_DunesWreckCopy", 
        "Обломок", 
        "Обломок Авроры."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string texturePath = Path.Combine(modFolder, "Assets", "World", "Drillable", "DrillableReefbackRock_texture.png"); //  <-- Путь к текстуре
    public static string specPath = Path.Combine(modFolder, "Assets", "World", "Drillable", "DrillableReefbackRock_spec.png"); //  <-- Путь к текстуре
    public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static Texture2D Specular = ImageUtils.LoadTextureFromFile(specPath);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "4698f370-fb13-40b3-a0b4-596edc047b52");
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
            GameObject door1 = obj.transform.Find("InteriorEntities/Starship_doors_frame(Placeholder)").gameObject;
            door1.name = "Door1";
            door1.transform.parent = obj.transform;
            GameObject door2 = obj.transform.Find("InteriorEntities/Wrecks_Starship_doors_sealed(Placeholder)").gameObject;
            door2.name = "Door2";
            door2.transform.parent = obj.transform;
            GameObject door3 = obj.transform.Find("InteriorEntities/Wrecks_Starship_doors_locked_nokey(Placeholder)").gameObject;
            door3.name = "Door3";
            door3.transform.parent = obj.transform;
            GameObject door4 = obj.transform.Find("InteriorEntities/Wrecks_Starship_doors_locked_nokey(Placeholder)").gameObject;
            door4.name = "Door4";
            door4.transform.parent = obj.transform;
            GameObject door5 = obj.transform.Find("InteriorEntities/Wrecks_Starship_doors_locked_nokey(Placeholder)").gameObject;
            door5.name = "Door5";
            door5.transform.parent = obj.transform;
            GameObject door6 = obj.transform.Find("InteriorEntities/Wrecks_Starship_doors_locked_nokey(Placeholder)").gameObject;
            door6.name = "Door6";
            door6.transform.parent = obj.transform;
            GameObject door7 = obj.transform.Find("InteriorEntities/Wrecks_Starship_doors_locked_nokey(Placeholder)").gameObject;
            door7.name = "Door7";
            door7.transform.parent = obj.transform;

            // Делаю бэкфлип
            GameObject exteriorEntities = obj.transform.Find("ExteriorEntities").gameObject;
            GameObject.Destroy(exteriorEntities);
            GameObject interiorEntities = obj.transform.Find("InteriorEntities").gameObject;
            GameObject.Destroy(interiorEntities);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

