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

public class ОбедФаберже
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Fabricator", "Food", "FabergeLunch.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "RP_FabergeLunch",
            "Обед Фаберже",
            "Питательный обед, основанный на творениях известного ювелира - Карла Фаберже. Яйцо Кальмаро-краба посыпанное золотой посыпкой, политое соусом из шипомётов. Из мраморной дыни выжимается сок, а оставшаяся масса собирается в сахарные бриллианты. Подается вместе со стаканом сока из мраморной дыни. От Вабита"
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2)); // РАЗМЕР В ИНВЕНТАРЕ
        //CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПАW
        _obj.ModifyPrefab += obj =>
        {
            //SkinnedMeshRenderer model = obj.GetComponentInChildren<SkinnedMeshRenderer>();
            //obj = model.gameObject;

            // Мы добавляем компонент, который даётся всей еде
            Eatable eatable = obj.EnsureComponent<Eatable>();
            eatable.foodValue = 70f;
            eatable.waterValue = 25f;

            // Отдельной функцией наш пискун будет добавлять кислород. Эта функция отдельна от eatable,
            // так что я предположу что для ней даже не обязателен компонент. Требуется тестирование
            // Наш пискун будет пополнять +10 кислорода
            SurvivalHandler.GiveOxygenOnConsume(Info.TechType, 10f, true);
            // Такое же есть и для хп. Наш пискун будет пополнять +10 хп
            SurvivalHandler.GiveHealthOnConsume(Info.TechType, 10f, true);
            // Вот этой функцией мы можем выставить заряд в биореакторе. Наш пискун даёт базе ровно 10 энергии
            BaseBioReactor.charge[Info.TechType] = 200f;
        };
        _prefab.SetUnlock(TechType.CrabsquidEgg);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new Ingredient(TechType.Salt, 2),
            new Ingredient(TechType.CrabsquidEgg, 1),
            new Ingredient(TechType.Melon, 2),
            new Ingredient(TechType.Gold, 1),
            new Ingredient(TechType.SpikePlantSeed, 2)
            //    РЕЦЕПТ КОНЕЦ
            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Survival", "CookedFood")
            .WithCraftingTime(10f); // ВРЕМЯ КРАФТА
        _prefab.SetPdaGroupCategory(TechGroup.Survival, TechCategory.CookedFood); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}

public class РецептОбед
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Salt, 2),
            new Ingredient(TechType.CrabsquidEgg, 1),
            new Ingredient(TechType.Melon, 2),
            new Ingredient(TechType.Gold, 1),
            new Ingredient(TechType.SpikePlantSeed, 2)
        }
        };
    }
}

