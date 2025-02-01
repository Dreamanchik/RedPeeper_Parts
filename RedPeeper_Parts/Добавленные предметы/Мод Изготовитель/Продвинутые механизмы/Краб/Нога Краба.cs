using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;
using UnityEngine;

public class НогаКраба
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "AdvancedElectronics", "Exosuit", "PrawnLeg.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "RPho_PrawnLeg",
            "Нога краба",
            "Механическая конечность, позволяющая крабу перемещаться по физической поверхности. Обладает эффективной термозащитой, формой захвата грунта и виброизоляцией, позволяя ему передвигаться по любого рода поверхностям."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 3)); // РАЗМЕР В ИНВЕНТАРЕ
        CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "4c924ad2-ab9a-4ff8-b2bd-3541b1b9d043"); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПА
        _obj.ModifyPrefab += obj =>
        {
            //Rigidbody rigidBody = obj.GetComponent<Rigidbody>();
            //rigidBody.drag = 0.1f;
            //rigidBody.angularDrag = 1f;
            obj.EnsureComponent<Pickupable>();
            GameObject legs = obj.transform.Find("exosuit_damaged_04")
            .gameObject.transform.Find("Exosuit_01_cabin006")
            .gameObject.transform.Find("Exosuit_01_pelvis006")
            .gameObject.transform.Find("Exosuit_01_Thigh_L006").gameObject;
            legs.transform.parent = obj.transform;
            GameObject remove = obj.transform.Find("exosuit_damaged_04").gameObject;
            GameObject.Destroy(remove);
            GameObject colliders = obj.transform.Find("exosuit_damaged_04_collisions").gameObject;
            GameObject deleteColliders = colliders.transform.Find("Capsule").gameObject;
            GameObject.Destroy(deleteColliders);
            deleteColliders = colliders.transform.Find("Cube (1)").gameObject;
            GameObject.Destroy(deleteColliders);
            GameObject moveColliders = colliders.transform.Find("Cube (3)").gameObject;
            BoxCollider boxCollider = moveColliders.GetComponent<BoxCollider>();
            boxCollider.enabled = false;
            moveColliders.transform.localPosition = new Vector3(-0.5f, -2f);
            legs.transform.localPosition = Vector3.zero;
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new Ingredient(TechType.Titanium)
            //    РЕЦЕПТ КОНЕЦ
            ))
            .WithCraftingTime(20f); // ВРЕМЯ КРАФТА
        _prefab.SetPdaGroupCategory(TechGroup.Machines, TechCategory.Machines); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}



public class РецептНогаКраба
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.PlasteelIngot, 1),
            new Ingredient(TechType.WiringKit, 2),
            new Ingredient(TechType.Aerogel, 1),
            new Ingredient(TechType.Silicone, 3)
        }
        };
    }
}