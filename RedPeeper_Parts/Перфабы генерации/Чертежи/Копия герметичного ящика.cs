using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SealedCrateCopy
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_SealedCrateCopy",
        "Корпоративный ящик с припасами",
        "С Авроры."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string texturePath = Path.Combine(modFolder, "Assets", "Doodads", "World", "SealedSupplyCrate", "SealedSupplyCrateTexture.png"); //  <-- Путь к текстуре
    public static string coverTexturePath = Path.Combine(modFolder, "Assets", "Doodads", "World", "SealedSupplyCrate", "SealedSupplyCrateCoverTexture.png"); //  <-- Путь к текстуре
    public static Texture2D modelTexture = ImageUtils.LoadTextureFromFile(texturePath);
    public static Texture2D coverTexture = ImageUtils.LoadTextureFromFile(texturePath);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "e837f37f-ed22-499d-b6ce-51f01b9602d8");
        _clone.ModifyPrefab += obj =>
        {
            // Удаляем лут
            GameObject signal = obj.transform.Find("Signal(Placeholder)").gameObject;
            GameObject.Destroy(signal);

            // Изменяю текстуру
            // Крышка
            MeshRenderer coverMR = obj.transform.Find("Crate_treasure_chest/Crate_treasure_chest_GRP/Crate_treasure_chest/Crate_chest_cover_ctrl/crate_chest_cover_GRP/Crate_treasure_chest_cover").gameObject.GetComponent<MeshRenderer>();
            coverMR.material.SetTexture(ShaderPropertyID._MainTex, modelTexture);
            // Ящик
            MeshRenderer modelMR = obj.transform.Find("Crate_treasure_chest/Crate_treasure_chest_GRP/Crate_treasure_chest").gameObject.GetComponent<MeshRenderer>();
            modelMR.material.SetTexture(ShaderPropertyID._MainTex, coverTexture);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}


