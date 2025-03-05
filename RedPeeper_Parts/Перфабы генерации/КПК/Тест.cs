using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Handlers;
using Nautilus.Utility;
using Story;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PDATest
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType(
        "RP_PDATest",
        "Герметичный ящик с припасами",
        "С Авроры."
        );

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "02dbd99a-a279-4678-9be7-a21202862cb7");
        _clone.ModifyPrefab += obj =>
        {
            StoryHandTarget pda = obj.GetComponent<StoryHandTarget>();
            pda.goal = new StoryGoal("RPPDATest", Story.GoalType.Encyclopedia, 0f);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}
public class PDATestEntry
{
    //public static StoryGoal RPPdaTest { get; private set; }
    public static void Register()
    {
        PDAHandler.AddEncyclopediaEntry(
        "RP_SandWorm",        // Айди
        "Lifeforms/Fauna/Deceased",  // Путь (https://subnauticamodding.github.io/Nautilus/tutorials/databank-entries.html#creating-an-entry-path)
        "Останки песчаного червя",          // Название
        "Известна новая информация о частично сохранившемся скелете вымершего левиафана, предположительно принадлежащего к вымершему биологическому виду песчаных червей. Останки содержат инородные структуры, в том числе инопланетные металлы, клетки и органы, что может свидетельствовать о непосредственной связи с технологиями инопланетной расы.\r\n Особенности\r\nСкелет оснащён мощными клешнями и панцирем, что указывает на возможное использование в качестве рабочей силы для добычи труднодоступных ресурсов и образцов фауны. Развитая мускулатура скелета предполагает высокую физическую силу, необходимую для выполнения сложных задач. Возраст останков оценивается в несколько сотен тысяч лет.\r\nПричина гибели\r\nАнализ структуры нейронных связей указывает на мгновенное прекращение активности мозга, возможно, вызванное преднамеренным воздействием ионной матрицы. Уникальный идентификатор матрицы позволяет предположить существование других порабощённых особей данного вида.\r\n\r\nОценка: Окаменелый скелет, содержащий уникальные образцы инопланетных технологий. Рекомендуется провести анализ ДНК."       // Описание
        );
    }
}


