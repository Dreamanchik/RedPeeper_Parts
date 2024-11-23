using JetBrains.Annotations;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Handlers;
using Nautilus.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

public static class RedPeeperFabricator_ПЕРЕИМЕНОВАТЬ
{
    public static PrefabInfo Info { get; private set; }
    public static CraftTree.Type craftTreeType;

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "StorageConcentrate.png");

    public static void Patch()
    {
        Info = PrefabInfo.WithTechType(
        "RedPeeper_Modified_Fabricator",
        "Модифицированный изготовитель",
        "Самодельное устройство, повторяющее и расширяющее функционал стандартного изготовителя. Конструкция этого изготовителя нарушает принципы протокола корпоративной собственности, что может привести к нарушению юрисдикции Альтерры. Применять на свой страх и риск."
        ).WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        var _prefab = new CustomPrefab(Info);
        var model = new FabricatorTemplate(_prefab.Info, craftTreeType)
        {
            FabricatorModel = FabricatorTemplate.Model.Workbench,
            ConstructableFlags = ConstructableFlags.Inside | ConstructableFlags.Ground | ConstructableFlags.Rotatable
        };
        _prefab.SetGameObject(model);
        _prefab.SetRecipe(new RecipeData(
            //    РЕЦЕПТ НАЧАЛО
            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.CopperWire, 1),
            new Ingredient(TechType.AcidMushroom, 4)
            //    РЕЦЕПТ КОНЕЦ
            ));
        _prefab.SetPdaGroupCategoryAfter(TechGroup.InteriorModules, TechCategory.InteriorModule, TechType.Fabricator);
        _prefab.Register();
    }
}
