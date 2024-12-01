using JetBrains.Annotations;
using Nautilus.Handlers;
using Nautilus.Utility;
using System.IO;
using System.Reflection;

public class Stage3_3x2
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string bgPath = Path.Combine(modFolder, "Assets", "Backgrounds", "Stage3_3x2.png");
    public static CraftData.BackgroundType BackgroundType = EnumHandler.AddEntry<CraftData.BackgroundType>("Stage3_3x2").WithBackground(ImageUtils.LoadSpriteFromFile(bgPath));
    //public static void Awake()
    //{
    //var Stage_1BG = EnumHandler.AddEntry<CraftData.BackgroundType>("Stage_1")
    //            .WithBackground(ImageUtils.LoadSpriteFromFile(bgPath));
    //}
}
