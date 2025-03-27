using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Handlers;
using Nautilus.Utility;
using RedPeeper_Parts;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class AncientSandworm
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_AncientSandworm", 
        "Окаменелые останки", 
        "Сохранившийся скелет песчаного червя. Рекомендуется провести анализ ДНК"
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        _prefab.SetGameObject(CreatePrefab());

        _prefab.Register();
    }
    private static GameObject CreatePrefab()
    {
        GameObject _obj = Plugin.AssetBundle.LoadAsset<GameObject>("horrorcrab");

        // The classID is the same as the one we put into the PrefabInfo.WithTechType up above
        // The LargeWorldEntity.CellLevel determines how far away the object will be loaded from the player
        PrefabUtils.AddBasicComponents(_obj, Info.ClassID, Info.TechType, LargeWorldEntity.CellLevel.Medium);

        // Makes the GameObject have the correct shaders
        // You can use the optional inputs here to change the look of your object
        MaterialUtils.ApplySNShaders(_obj);


        PDAHandler.AddCustomScannerEntry(Info.TechType, 10f, false, "RP_SandWorm"); //Течтайп, сколько секунд сканировать, уничтожать ли при сканировании, айди лога

        // Return the GameObject with all the components added
        return _obj;
    }
}
public class AncientSandwormPDA
{
    //public static StoryGoal RPPdaTest { get; private set; }
    public static void Register()
    {
        PDAHandler.AddEncyclopediaEntry(
        "RP_SandWorm",        // Айди
        "Lifeforms/Fauna/Deceased",  // Путь (https://subnauticamodding.github.io/Nautilus/tutorials/databank-entries.html#creating-an-entry-path)
        "Останки песчаного червя",          // Название
        "Известна новая информация о частично сохранившемся скелете вымершего левиафана, предположительно принадлежащего к вымершему биологическому виду песчаных червей. Останки содержат инородные структуры, в том числе инопланетные металлы, клетки и органы, что может свидетельствовать о непосредственной связи с технологиями инопланетной расы. \r\n\r\n1.Особенности: \n Скелет оснащён мощными клешнями и панцирем, что указывает на возможное использование в качестве рабочей силы для добычи труднодоступных ресурсов и образцов фауны. Развитая мускулатура скелета предполагает высокую физическую силу, необходимую для выполнения сложных задач. Возраст останков оценивается в несколько сотен тысяч лет. \r\n\r\n2.Причина гибели:\r\nАнализ структуры нейронных связей указывает на мгновенное прекращение активности мозга, возможно, вызванное преднамеренным воздействием ионной матрицы. Уникальный идентификатор матрицы позволяет предположить существование других порабощённых особей данного вида.\r\n\r\nОценка: Окаменелый скелет, содержащий уникальные образцы инопланетных технологий. Рекомендуется провести анализ ДНК."       // Описание
        );
    }
}

