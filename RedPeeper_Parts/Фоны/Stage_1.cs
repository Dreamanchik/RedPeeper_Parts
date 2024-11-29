using JetBrains.Annotations;
using Nautilus.Handlers;
using Nautilus.Utility;
using System.IO;
using System.Reflection;

public class Stage_1
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string bgPath = Path.Combine(modFolder, "Assets", "Backgrounds", "Stage_1.png");
    public static CraftData.BackgroundType BackgroundType = EnumHandler.AddEntry<CraftData.BackgroundType>("Stage_1").WithBackground(ImageUtils.LoadSpriteFromFile(bgPath));
    //public static void Awake()
    //{
    //var Stage_1BG = EnumHandler.AddEntry<CraftData.BackgroundType>("Stage_1")
    //            .WithBackground(ImageUtils.LoadSpriteFromFile(bgPath));
    //}
}
