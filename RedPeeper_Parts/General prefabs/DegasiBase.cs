using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DegasiBase
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBaseTemplate1", "База дегази", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "8f20a08c-c981-4fad-a57b-2de2106b8abf");
        _clone.ModifyPrefab += obj =>
        {
            GameObject[] toDelete = new GameObject[]
                {
                    //LifePodSeat1Model.transform.parent.Find("exterior").gameObject,
                    //LifePodSeat1Model.transform.parent.Find("interior").gameObject,
                    //obj.transform.Find("LOD").gameObject
                };

        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

