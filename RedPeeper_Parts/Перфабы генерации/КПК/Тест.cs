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
        "RPPDATest",        // Айди
        "Lifeforms/Fauna",  // Путь (https://subnauticamodding.github.io/Nautilus/tutorials/databank-entries.html#creating-an-entry-path)
        "Skibidi",          // Название
        "Dop dop dop"       // Описание
        );
    }
}


