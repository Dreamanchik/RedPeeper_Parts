﻿using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;

public class СолнечнаяЯчейкаДатабокс2
{
  
    public static PrefabInfo Info { get; private set; }

    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_SolarCellDatabox2",
            "Ящик с данными",
            "Содержит чертёж солнечной ячейки."
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