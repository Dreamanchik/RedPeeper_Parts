using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;

public class СветоваяБатареяДатабокс
{

    public static PrefabInfo Info { get; private set; }

    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_LightBattertDatabox",
            "Ящик с данными",
            "Содержит чертёж световой батареи."
            );
        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "02c0e341-6de9-466a-9c25-9a667ddb6158"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            BlueprintHandTarget blueprint = obj.GetComponent<BlueprintHandTarget>();
            blueprint.unlockTechType = СветоваяБатарейка.Info.TechType;
        };
        _prefab.SetUnlock(TechType.MembrainTreeSeed);
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // Регистрация
    }
}
