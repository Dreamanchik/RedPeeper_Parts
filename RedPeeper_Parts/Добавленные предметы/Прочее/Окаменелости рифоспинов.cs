using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using UnityEngine;

public class ОкаменелостиРифоспинов
{
    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Materials", "ReefbackRock.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_ReefbackRock",
            "Окаменелости рифоспинов",
            "Древнее окаменелое образование, появившееся в результате жизнедеятельности дальних предков рифоспина. Состоит из тонких нарезных слоёв, схожих по структуре с мембранами."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "a711c0fa-f31e-4426-9164-a9a65557a9a2"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            Vector3 size = new Vector3(0.6f, 0.6f, 0.6f);
            obj.transform.localScale = size;
            obj.EnsureComponent<Pickupable>();
            Rigidbody rigidBody = obj.EnsureComponent<Rigidbody>();
            rigidBody.drag = 1;
            rigidBody.angularDrag = 1;
            rigidBody.mass = 10;
            rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            rigidBody.isKinematic = false;
            rigidBody.useGravity = false;
            obj.EnsureComponent<WorldForces>();
            WorldForces worldForces = obj.GetComponent<WorldForces>();
            worldForces.handleGravity = true;
            worldForces.aboveWaterGravity = 10;
            worldForces.underwaterGravity = 1;
            worldForces.handleDrag = true;
            worldForces.aboveWaterDrag = 0.1f;
            worldForces.underwaterDrag = 1;
            worldForces.useRigidbody = rigidBody;
            worldForces.detectionState = true;
        };
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // Регистрация
    }
}
