using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

public class DrillableReefbackRock
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "DrillableReefbackRock", 
        "Окаменелости Рифоспинов", 
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
        CloneTemplate _clone = new CloneTemplate(Info, "06ada673-7d2b-454f-ae11-951d628e64a7");
        _clone.ModifyPrefab += obj =>
        {
            PrefabUtils.AddResourceTracker(obj, ОкаменелостиРифоспинов.Info.TechType);
            Drillable drillable = obj.EnsureComponent<Drillable>(); 
            Drillable.ResourceType[] resources = drillable.resources;
            int num = 0;
            Drillable.ResourceType resourceType = default(Drillable.ResourceType);
            resourceType.chance = 1;
            resourceType.techType = ОкаменелостиРифоспинов.Info.TechType;
            resources[num] = resourceType;

            MeshRenderer mr1 = obj.transform.Find("Mercury_ore/mercury_ore_01").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr2 = obj.transform.Find("Mercury_ore/mercury_ore_02").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr3 = obj.transform.Find("Mercury_ore/mercury_ore_03").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr4 = obj.transform.Find("Mercury_ore/mercury_ore_04").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr5 = obj.transform.Find("Mercury_ore/mercury_ore_05").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr6 = obj.transform.Find("Mercury_ore/mercury_ore_06").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr7 = obj.transform.Find("Mercury_ore/mercury_ore_07").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr8 = obj.transform.Find("Mercury_ore/mercury_ore_08").gameObject.GetComponent<MeshRenderer>();
            MeshRenderer mr9 = obj.transform.Find("Mercury_ore/mercury_ore_09").gameObject.GetComponent<MeshRenderer>();
            mr1.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr1.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr2.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr2.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr3.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr3.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr4.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr4.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr5.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr5.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr6.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr6.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr7.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr7.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr8.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr8.material.SetTexture(ShaderPropertyID._MainTex, Texture);
            mr9.material.SetTexture(ShaderPropertyID._SpecTex, Specular);
            mr9.material.SetTexture(ShaderPropertyID._MainTex, Texture);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

