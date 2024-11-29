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

public class RedPeeper_TrainingPeeper
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "StorageConcentrate.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "TrainingPeeper",
            "(ДЕВ) Тренировочный пискун",
            "(ДЕВ) Непробиваемый как скала пискун-манекен, приспособленный к любого рода средам, воздействиям и условиям. Функционал неограничен"
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(1, 2)); // РАЗМЕР В ИНВЕНТАРЕ
        //CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Peeper); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПАW
        _obj.ModifyPrefab += obj =>
        {
            //SkinnedMeshRenderer model = obj.GetComponentInChildren<SkinnedMeshRenderer>();
            //obj = model.gameObject;
            Eatable eatable = obj.EnsureComponent<Eatable>();
            eatable.foodValue = 10f;
            BaseBioReactor.charge[Info.TechType] = 10f;
            SurvivalHandler.GiveHealthOnConsume(Info.TechType, 10f, true);
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.CopperWire, 1),
            new Ingredient(TechType.AcidMushroom, 4)
            //    РЕЦЕПТ КОНЕЦ
            ))
            .WithFabricatorType(RedPeeperFabricator_ПЕРЕИМЕНОВАТЬ.craftTreeType)
            .WithStepsToFabricatorTab("ShitMenu")
            .WithCraftingTime(3f); // ВРЕМЯ КРАФТА
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.AdvancedMaterials); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}