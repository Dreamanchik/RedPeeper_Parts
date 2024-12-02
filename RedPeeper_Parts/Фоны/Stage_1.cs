using JetBrains.Annotations;
using Nautilus.Handlers;
using Nautilus.Utility;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering;

public class Stage3_3x2
{
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string bgPath = Path.Combine(modFolder, "Assets", "Backgrounds", "Stage_1.png");
    public static CraftData.BackgroundType BackgroundType = EnumHandler.AddEntry<CraftData.BackgroundType>("Stage_1").WithBackground(ImageUtils.LoadSpriteFromFile(bgPath));
    /*private static Texture2D ReferenceTexture
    {
        get
        {
            _referenceTexture = ImageUtils.LoadTextureFromFile(bgPath);
            return _referenceTexture;
        }
    }
    private static Texture2D _referenceTexture;
    public static Atlas.Sprite TextureToBGSSprite(Texture2D texture)
    {
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        return new Atlas.Sprite(texture);
    }
    public static Texture2D LoadTextureFromFile(string FilePathToImage)
    {
        byte[] array = File.ReadAllBytes(FilePathToImage);
        Texture2D texture2D = new Texture2D(2, 2, GraphicsFormat.RGBA_BC7_SRGB, 0, TextureCreationFlags.None);
        ImageConversion.LoadImage(texture2D, array);
        return null;
    }
    public static Atlas.Sprite CreatePaintedIcon(Color color)
    {
        var grayscale = ReferenceTexture;
        return TextureToBGSSprite(PaintGrayscaleTexture(grayscale), color));
    }
    private static Color PaintGrayPixel(Color gray, Color hue)
    {
        return new Color(gray.r * hue.r, gray.g * hue.g, gray.b * hue.b, gray.a * hue.a);
    }
    private static Texture2D PaintGrayscaleTexture(Texture2D grayscale, Color newColor)
    {
        Texture2D newTex = new Texture2D(grayscale.width, grayscale.height, TextureFormat.ARGB32, false);
        var fillPixels = new Color[newTex.width * newTex.height];
        for (int i = 0; i < fillPixels.Length; i++)
        {
            fillPixels[i] = Color.clear;
        }
        newTex.SetPixels(fillPixels);

        for (int x = 0; x < grayscale.width; x++) 
        { 
            for (int y = 0; y < grayscale.height; y++)
            {
                newTex.SetPixel(x, y, PaintGrayPixel(grayscale.GetPixel(x, y), newColor));
            }
        }
        newTex.Apply();

        return newTex;
    }
    /*private static bool LinearColorSpace
    {
        get
        {
            return true;
        }
    }*/
    //public static void Awake()
    //{
    //var Stage_1BG = EnumHandler.AddEntry<CraftData.BackgroundType>("Stage_1")
    //            .WithBackground(ImageUtils.LoadSpriteFromFile(bgPath));
    //}
}
