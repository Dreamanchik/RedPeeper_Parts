using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

public class КаменьБезФизики4
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_RockFreeze4", 
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
        CloneTemplate _clone = new CloneTemplate(Info, "10b24c9a-4449-47da-8ca3-a6a44b9de945");
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

