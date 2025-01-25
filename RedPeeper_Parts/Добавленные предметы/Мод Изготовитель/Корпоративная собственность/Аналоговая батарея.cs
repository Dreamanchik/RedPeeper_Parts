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
using UnityEngine.Assertions;

public class АналоговаяБатарея
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "CorporateTools", "AnalogBattery.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>

    // public static string texturePath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "SpatialProcessor_texture.png"); //  <-- Путь к текстуре
   //  public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static void Register()



         {
            Info = PrefabInfo.WithTechType(
            "RP_AnalogBattery",
            "Аналоговая батарея",
            "Применяемая в тяжелой промышленности батарея, способная накапливать большое количество энергии за счёт уранового накопителя. Из-за особенности конструкции не может быть использована в качестве персональной батареи."
         )


            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2));
            //CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН

            var _prefab = new CustomPrefab(Info);
            var _obj = new CloneTemplate(Info, TechType.DepletedReactorRod); // Перфаб

        _obj.ModifyPrefab += obj =>
        {
            // MeshRenderer mr = obj.transform.Find("model").gameObject.transform.Find("Mesh").gameObject.GetComponent<MeshRenderer>();
            // mr.material.mainTexture = Texture;
            // mr.material.SetTexture(ShaderPropertyID._Diffusion, Texture);
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            //   Рецепт
            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.UraniniteCrystal, 2),
            new Ingredient(TechType.Titanium, 2),
            new Ingredient(TechType.CopperWire)
            ))
            .WithCraftingTime(15f); // ВРЕМЯ КРАФТА
            // _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.AdvancedMaterials); // МЕСТОНАХОЖДЕНИЕ В КПК

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}
