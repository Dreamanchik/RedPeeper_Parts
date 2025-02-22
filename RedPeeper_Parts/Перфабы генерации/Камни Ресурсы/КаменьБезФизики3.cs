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

public class КаменьБезФизики3
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_RockFreeze3", 
        "Камень", 
        "Камень."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string texturePath = Path.Combine(modFolder, "Assets", "World", "Drillable", "DrillableReefbackRock_texture.png"); //  <-- Путь к текстуре
    public static string specPath = Path.Combine(modFolder, "Assets", "World", "Drillable", "DrillableReefbackRock_spec.png"); //  <-- Путь к текстуре
    public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static Texture2D Specular = ImageUtils.LoadTextureFromFile(specPath);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "e28463e6-ee38-4722-9d83-7d455ec2975f");
        _clone.ModifyPrefab += obj =>
        {
            Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            obj.EnsureComponent<ImmuneToPropulsioncannon>();
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

