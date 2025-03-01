using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Assets.Gadgets;
using Nautilus.Handlers;
using System.Collections.Generic;

public class Мембрана2
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "ModifiedFabricator", "Components", "Membrane.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "RP_MembraneAlternate",
            "Мембрана",
            "Тонкая органическая пластина, синтезированная из образцов мембранного дерева. Подходит для создания герметичных упаковок и высокотехнологичных линз."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2)); // РАЗМЕР В ИНВЕНТАРЕ
            CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.PlantWaterSeed); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.ComputerChip); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПАW
        _obj.ModifyPrefab += obj =>
        {
            BaseBioReactor.charge[Info.TechType] = 120f;
        };
        _prefab.SetUnlock(TechType.MembrainTreeSeed);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new CraftData.Ingredient(TechType.Titanium, 1000)
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



public class РецептМембраны2
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        List<TechType> linkedItems = new List<TechType>()
        {
        Мембрана.Info.TechType
        };
        return new RecipeData()
        {
            craftAmount = 0,
            LinkedItems = linkedItems,

            Ingredients =
        {
            new CraftData.Ingredient(ОкаменелостиРифоспинов.Info.TechType, 2)
        }
        };
    }
}