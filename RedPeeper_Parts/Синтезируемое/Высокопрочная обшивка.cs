using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class ВысокопрочнаяОбшивка
{
    //    ЧТОБЫ ПРЕДМЕТ МОЖНО БЫЛО ИСПОЛЬЗОВАТЬ ГДЕ УГОДНО. ДЛЯ ЭТОГО НУЖНО ПРОСТО ВПИСАТЬ (Название класса).Info.(Название функции. Например, TechType). КАК ПРИМЕР - RedPeeper_CyclopsEngine.Info.TechType
    public static PrefabInfo Info { get; private set; }

    //    ИКОНКА
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Synthesis", "HighStrengthCladding.png"); // <-- Заменить на нужное. ОГРОМНОЕ ЖЕЛАНИЕ ПАПКИ ДЕЛАТЬ ТАКИМИ ЖЕ КАК И В ПРОЕКТЕ. Структура должна совпадать с папками в моде. Тоесть, если иконка просто находится в папке Assets, то код будет выглядеть как <<"Assets", "CyclopsEngine.png">>, а если находится с папке Assets и потом в папке Items, потом Cyclops и потом Objects, то <<"Assets", "Items", "Cyclops", "Objects", "CyclopsEngine.png">>
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            //    АЙДИ, НАЗВАНИЕ, ОПИСАНИЕ
            "RedPeeper_High_Strength_Cladding",
            "Высокопрочная обшивка",
            "Прочный, проводящий и лёгкий материал. Обладает универсальными функциями покраски, плавучести и водостойкости. Широко применяется в производстве сложного технического оборудования и конструкционных частей транспорта."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(5, 3)); // РАЗМЕР В ИНВЕНТАРЕ
        //CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm); // ФОН

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Magnesium); // КОПИРУЕМ ПРЕФАБ НА ОСНОВЕ ТЕЧТАЙПА
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // РЕГИСТРАЦИЯ ОБЪЕКТА. ПОСЛЕ ЭТОГО НИЧЕГО НЕ ПИШЕМ
    }
}
