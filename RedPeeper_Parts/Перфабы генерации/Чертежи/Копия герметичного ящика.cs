using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SealedCrateCopy
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_SealedCrateCopy",
        "Герметичный ящик с припасами",
        "С Авроры."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "e837f37f-ed22-499d-b6ce-51f01b9602d8");
        _clone.ModifyPrefab += obj =>
        {
            // Удаляем лут
            GameObject signal = obj.transform.Find("Signal(Placeholder)").gameObject;
            GameObject.Destroy(signal);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}


