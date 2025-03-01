using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using System.IO;
using System.Reflection;
using UnityEngine;

public class CrateCopy
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_CrateCopy",
        "Ящик с припасами",
        "С Авроры."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "cb2e9dc9-cfdc-48e1-ac8e-997d354d759b");
        _clone.ModifyPrefab += obj =>
        {
            // Удаляем лут
            GameObject signal = obj.transform.Find("NutrientBlock(Placeholder)").gameObject;
            GameObject.Destroy(signal);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}


