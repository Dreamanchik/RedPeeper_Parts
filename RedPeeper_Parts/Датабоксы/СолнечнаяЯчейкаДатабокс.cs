using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Assets.Gadgets;
using Nautilus.Handlers;
using UnityEngine;

public class СолнечнаяЯчейкаДатабокс2
{
  
    public static PrefabInfo Info { get; private set; }

    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_SolarCellDatabox2",
            "ИЗМЕНИТЬ",
            "ИЗМЕНИТЬ"
            );
        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "02c0e341-6de9-466a-9c25-9a667ddb6158"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            BlueprintHandTarget blueprint = obj.GetComponent<BlueprintHandTarget>();
            blueprint.unlockTechType = СолнечнаяЯчейка.Info.TechType;
        };
        _prefab.SetUnlock(TechType.MembrainTreeSeed);
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // Регистрация
    }
}