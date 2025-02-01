using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DrillablePeeper
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DrillablePeeper", "Кто это наделал с моим камнем :((", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "026d91e2-430b-4c6d-8bd4-b51e270d5eed");
        _clone.ModifyPrefab += obj =>
        {
            Drillable drillable = obj.EnsureComponent<Drillable>();
            Drillable.ResourceType[] resources = drillable.resources;
            int num = 0;
            Drillable.ResourceType resourceType = default(Drillable.ResourceType);
            resourceType.chance = 1;
            resourceType.techType = TechType.Peeper;
            resources[num] = resourceType;
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

