using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using UnityEngine;

public class ЯйцоРифоспина
{
    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Materials", "ReefbackRock.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_ReefbackEgg",
            "Окаменелости рифоспинов",
            "Древнее окаменелое образование, появившееся в результате жизнедеятельности дальних предков рифоспина. Состоит из тонких нарезных слоёв, схожих по структуре с мембранами."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "4f4bdec2-67a9-425d-b317-0ee3f949d481"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            CapsuleCollider capsuleCollider = obj.AddComponent<CapsuleCollider>();
            capsuleCollider.radius = 0.54f;
            capsuleCollider.height = 1.5f;
            capsuleCollider.direction = 1;
            capsuleCollider.center = new Vector3(0.03f, 0.63f, 0);
        };
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // Регистрация
    }
}