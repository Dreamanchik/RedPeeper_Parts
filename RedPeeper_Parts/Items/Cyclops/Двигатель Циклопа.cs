using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class RedPeeper_CyclopsEngine
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }
    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Cyclops", "CyclopsEngine.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "RedPeeper_Cyclops_Engine",
            "Двигатель Циклопа",
            "Высокотехнологичный и громоздкий двигатель, способный вырабатывать огромную механическую тягу, позволяя Циклопу передвигаться. Имеет встроенную консоль модификации. Склонен к перегреву при слишком высокой нагрузке."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 4)); // РАЗМЕР В ИНВЕНТАРЕ
        //CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН
        CraftDataHandler.SetBackgroundType(Info.TechType, Stage_1.BackgroundType); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Magnesium); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПА
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new Ingredient(TechType.TitaniumIngot, 3),
            new Ingredient(TechType.Lubricant, 8),
            new Ingredient(TechType.ComputerChip, 3),
            new Ingredient(TechType.Silicone, 2),
            new Ingredient(TechType.PowerCell, 6)
            //    РЕЦЕПТ КОНЕЦ
            ))
            .WithFabricatorType(CraftTree.Type.Workbench) // В 2.0 отказались от вкладок в мод станции, я не знаю зачем
            .WithCraftingTime(60f); // ВРЕМЯ КРАФТА
        _prefab.SetPdaGroupCategory(TechGroup.Cyclops, TechCategory.Cyclops); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}