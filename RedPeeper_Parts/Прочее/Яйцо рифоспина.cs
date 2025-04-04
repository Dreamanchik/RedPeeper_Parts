using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Handlers;
using UnityEngine.AddressableAssets;

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
            PDAHandler.AddCustomScannerEntry(Info.TechType, 4f, false, "RP_ReefbackNestPDA");
        };
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // Регистрация
    }
}

public class ReefbackNestPDA
{
    //public static StoryGoal RPPdaTest { get; private set; }
    public static void Register()
    {
        PDAHandler.AddEncyclopediaEntry(
        "RP_ReefbackNestPDA",        // Айди
        "Advanced",  // Путь (https://subnauticamodding.github.io/Nautilus/tutorials/databank-entries.html#creating-an-entry-path)
        "Места гнездования рифоспинов",          // Название
        "\r\nОбзор:\r\nМеста гнездования рифоспинов представляют собой глубоководные территории, используемые для защиты и выращивания молодняка. Эти структуры играют ключевую роль в поддержании популяции рифоспинов, обеспечивая укрытие и источник питания.\r\n\r\nОсобенности:\r\nГнёзда построены из камней и кластеров глубоководной травы, которые рифоспины переносят на своих телах. Структуры расположены на значительной глубине, что обеспечивает защиту от большинства потенциальных хищников. После падения кораблей \"Аврора\" и \"Дегази\" в структуру гнёзд стали включаться металлические обломки, что свидетельствует об адаптивности вида.\r\n\r\nЭкологическая роль:\r\nМолодые рифоспины питаются окаменелыми останками взрослых особей, что способствует перераспределению питательных веществ в экосистеме. Гнёзда также служат укрытием для других глубоководных организмов, формируя сложную структуру биологических процессов.\r\n\r\nУгрозы:\r\nРифоспины крайне чувствительны к изменениям в окружающей среде. Падение Авроры вызвало разрушение многих биологических цепочек, изменение течений и шумовое загрязнение, что привело к миграции популяции в более безопасные экологические среды. Это нарушило баланс экосистемы, повлияв и на другие виды фауны.\r\n\r\nОценка: Уцелевшее гнездо рифоспинов, содержащее большое количество окаменелых останков."       // Описание
        );
    }
}