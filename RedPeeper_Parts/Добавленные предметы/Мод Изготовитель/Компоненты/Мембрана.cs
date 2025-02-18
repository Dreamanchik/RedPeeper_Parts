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
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "Membrane", "Membrane.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>

    public static string mainTexturePath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "Membrane", "Membrane_Texture.png");
    public static string specPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "Membrane", "Membrane_Spec.png");//  <-- Путь к текстуре
    public static Texture2D texture = ImageUtils.LoadTextureFromFile(mainTexturePath);
    public static Texture2D spec = ImageUtils.LoadTextureFromFile(mainTexturePath);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "RP_Membrane",
            "Мембрана",
            "Тонкая органическая пластина, синтезированная из биологических образцов флоры и фауны. Подходит для создания герметичных упаковок и высокотехнологичных линз."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2)); // РАЗМЕР В ИНВЕНТАРЕ
            CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.PlantWaterSeed); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.CoralChunk); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПАW
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
            //    РЕЦЕПТ НАЧАЛО
            new CraftData.Ingredient(Герметик.Info.TechType),
            new CraftData.Ingredient(TechType.MembrainTreeSeed, 2)
            //    РЕЦЕПТ КОНЕЦ
            ))
            //.WithFabricatorType(CraftTree.Type.Fabricator)
            .WithCraftingTime(5f); // ВРЕМЯ КРАФТА
        //_prefab.SetRecipe(GetRecipeData()).WithFabricatorType(CraftTree.Type.Fabricator).WithStepsToFabricatorTab("Rsources", "BasicMaterials").WithCraftingTime(5f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.AdvancedMaterials); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
    /*public static RecipeData GetRecipeData()
    {
        return new RecipeData(
            new CraftData.Ingredient(Герметик.Info.TechType),
            new Ingredient(TechType.MembrainTreeSeed, 2)
        );
    }*/
}



public class РецептМембраны
{
    // Изменяем рецепт
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