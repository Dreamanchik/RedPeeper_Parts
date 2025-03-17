using FMOD;
using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Handlers;
using Nautilus.Utility;
using Story;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RadioTest
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string soundPath = Path.Combine(modFolder, "Assets", "Sounds", "tuco-get-out.mp3");
    public static ItemGoal LifepodRadiosignal { get; private set; }
    public static void Register()
    {
        LifepodRadiosignal = StoryGoalHandler.RegisterItemGoal("RP_BrokenLifepodAudio", Story.GoalType.Radio, TechType.TitaniumIngot);
        Sound sound = AudioUtils.CreateSound(soundPath, MODE._2D | MODE.ACCURATETIME);
        CustomSoundHandler.RegisterCustomSound("RP_BrokenLifepodAudio", sound, "bus:/master/SFX_for_pause/PDA_pause/all/all voice/VOs");
        PDAHandler.AddLogEntry("RP_BrokenLifepodAudio", "RP_BrokenLifepodAudio", AudioUtils.GetFmodAsset("RP_BrokenLifepodAudio"));
        StoryGoalHandler.RegisterOnGoalUnlockData("RP_OnPlayBrokenLifepodAudio", null, new UnlockSignalData[]
        {
            new UnlockSignalData
            {
                targetPosition = new Vector3(2000f, 2000f, 2000f),
                targetDescription = "The Mimic"
            }
        }, null, null);
    }
}
public class RadioTestEntry
{
    public static void Register()
    {
        PDAHandler.AddEncyclopediaEntry(
        "RP_BrokenLifepod",          // Айди
        "Lifeforms/Fauna/Deceased",  // Путь (https://subnauticamodding.github.io/Nautilus/tutorials/databank-entries.html#creating-an-entry-path)
        "Капсула 8888",              // Название
        "Её положение неизвестно!!!!!!"       // Описание
        );
    }
}


