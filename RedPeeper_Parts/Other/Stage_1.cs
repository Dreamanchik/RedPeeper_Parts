using Nautilus.Handlers;
using Nautilus.Utility;
using System.IO;
using System.Reflection;

public class Stage_1
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string bgPath = Path.Combine(modFolder, "Assets", "BG", "Stage_1.png");
    private void Awake()
    {
    var myCustomBackground = EnumHandler.AddEntry<CraftData.BackgroundType>("Stage_1")
                .WithBackground(ImageUtils.LoadSpriteFromFile(bgPath));
    }
}
