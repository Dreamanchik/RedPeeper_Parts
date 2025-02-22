using Nautilus.Assets;
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
        
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

