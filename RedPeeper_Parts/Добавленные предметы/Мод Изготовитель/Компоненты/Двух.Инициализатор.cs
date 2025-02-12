using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;
using Nautilus.Extensions;
using Nautilus.Handlers;
using UnityEngine;

public class ДвухфакторныйИнициализатор
{
    public static PrefabInfo Info { get; private set; }
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "TwoFactorProcessor", "TwoFactorProcessor.png");

    public static string texturePath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "TwoFactorProcessor_texture.png");
    public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_TwofactorProcessor",
            "Двухфакторный инициализатор",
            "Модифицированный процессор, блокирующий все внешние ограничения, устанавливаемые встроенным ПО. Использование подобного рода электроники нарушает протокол корпоративной собственности Альтерры. Применять на свой страх и риск."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            MeshRenderer mr = obj.transform.Find("model").gameObject.transform.Find("Mesh").gameObject.GetComponent<MeshRenderer>();
            mr.material.mainTexture = Texture;
            mr.material.SetTexture(ShaderPropertyID._Diffusion, Texture);
        };
        _prefab.SetUnlock(TechType.JellyPlant);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    Рецепт
            new Ingredient(TechType.Magnetite, 5),
            new Ingredient(TechType.CopperWire, 3),
            new Ingredient(TechType.WiringKit),
            new Ingredient(TechType.ComputerChip)
            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "Electronics")
            .WithCraftingTime(10f); // Крафт
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics); // КПК

        _prefab.Register(); // Регистрация


    }
}

public class РецептИнициализатор
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Magnetite, 5),
            new Ingredient(TechType.CopperWire, 3),
            new Ingredient(TechType.WiringKit),
            new Ingredient(TechType.ComputerChip)
        }
        };
    }
}
