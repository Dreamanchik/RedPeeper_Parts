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
            // Удаляю лут (страшно)
            GameObject signal = obj.transform.Find("NutrientBlock(Placeholder)").gameObject;
            GameObject.Destroy(signal);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}


