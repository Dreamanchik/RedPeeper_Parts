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

public class Мембрана
{
  
    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "Membrane", "Membrane.png");

    public static string mainTexturePath = Path.Combine(modFolder, "Assets", "Doodabs", "ModifiedFabricator", "Components", "Membrane", "Membrane_Texture.png");
    public static string specPath = Path.Combine(modFolder, "Assets", "Doodabs", "ModifiedFabricator", "Components", "Membrane", "Membrane_Spec.png");//  <-- Путь к текстуре
    public static Texture2D texture = ImageUtils.LoadTextureFromFile(mainTexturePath);
    public static Texture2D spec = ImageUtils.LoadTextureFromFile(mainTexturePath);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_Membrane",
            "Мембрана",
            "Тонкая органическая пластина, синтезированная из биологических образцов флоры и фауны. Подходит для создания герметичных упаковок и высокотехнологичных линз."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2));
            CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.PlantWaterSeed);
        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.CoralChunk); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            BaseBioReactor.charge[Info.TechType] = 120f;
            MeshRenderer mr = obj.transform.Find("Coral_reef_shell_01").gameObject.GetComponent<MeshRenderer>();
            mr.material.SetTexture(ShaderPropertyID._MainTex, texture);
            mr.material.SetTexture(ShaderPropertyID._SpecTex, spec);
        };
        _prefab.SetUnlock(TechType.MembrainTreeSeed);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new CraftData.Ingredient(Герметик.Info.TechType),
            new CraftData.Ingredient(TechType.MembrainTreeSeed, 2)

            ))
            .WithCraftingTime(5f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.AdvancedMaterials); // КПК

        _prefab.Register(); // Регистрация
    }
}



public class РецептМембраны
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(Герметик.Info.TechType),
            new CraftData.Ingredient(TechType.MembrainTreeSeed, 2)
        }
        };
    }
}