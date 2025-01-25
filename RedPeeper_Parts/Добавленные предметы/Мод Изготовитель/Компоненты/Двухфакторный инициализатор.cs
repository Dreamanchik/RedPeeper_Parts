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
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "TwoFactorProcessor", "TwoFactorProcessor.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>

    public static string texturePath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "TwoFactorProcessor_texture.png"); //  <-- Путь к текстуре
    public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "RP_TwofactorProcessor",
            "Двухфакторный инициализатор",
            "Модифицированный процессор, блокирующий все внешние ограничения, устанавливаемые встроенным ПО. Использование подобного рода электроники нарушает протокол корпоративной собственности Альтерры. Применять на свой страх и риск."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2)); // РАЗМЕР В ИНВЕНТАРЕ
        //CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПАW
        _obj.ModifyPrefab += obj =>
        {
            MeshRenderer mr = obj.transform.Find("model").gameObject.transform.Find("Mesh").gameObject.GetComponent<MeshRenderer>();
            mr.material.mainTexture = Texture;
            mr.material.SetTexture(ShaderPropertyID._Diffusion, Texture);
        };
        _prefab.SetUnlock(TechType.JellyPlant);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new Ingredient(TechType.Magnetite, 5),
            new Ingredient(TechType.CopperWire, 3),
            new Ingredient(TechType.WiringKit),
            new Ingredient(TechType.ComputerChip)
            //    РЕЦЕПТ КОНЕЦ
            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "Electronics")
            .WithCraftingTime(10f); // ВРЕМЯ КРАФТА
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}
