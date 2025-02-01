using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePieceXCorridor
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePieceXCorridor", "База дегази", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "99b164ac-dfb4-4a14-b305-8666fa227717");
        _clone.ModifyPrefab += obj =>
        {
            GameObject _delete;

            // Удаляем остальные части базы
            GameObject _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete1";
            _delete = obj.transform.Find("delete1").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete2";
            _delete = obj.transform.Find("delete2").gameObject;
            GameObject.Destroy(_delete);

            // Оставляем только одну часть базы
            GameObject _actualModel = obj.transform.Find("BaseCell").gameObject;
            // Переименовываем в PieceModel
            _actualModel.name = "PieceModel";
            GameObject _narrower = _actualModel.transform.Find("BaseAbandonedCorridorXShape/models/bendCap_zp_narrower (2)").gameObject;
            _narrower.transform.localPosition = new Vector3(0f, 0f, 5.2f);
            GameObject _narrower2 = _actualModel.transform.Find("BaseAbandonedCorridorXShape/models/bendCap_zp_narrower (3)").gameObject;
            _narrower2.transform.localPosition = new Vector3(-0.12f, 0f, 0f);

            // Удаляем остальные части базы
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete3";
            _delete = obj.transform.Find("delete3").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete4";
            _delete = obj.transform.Find("delete4").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete5";
            _delete = obj.transform.Find("delete5").gameObject;
            GameObject.Destroy(_delete);

            // Убираю опоры
            _delete = _actualModel.transform.Find("BaseAbandonedCorridorIShapeSupport").gameObject;
            GameObject.Destroy(_delete);

            // Я ненавижу эту дверь >:(
            _delete = _actualModel.transform.Find("BaseAbandonedCorridorBulkhead").gameObject;
            GameObject.Destroy(_delete);

            _delete = _actualModel.transform.Find("IslandsPDABase1Storm(Placeholder)").gameObject;
            GameObject.Destroy(_delete);
            
            GameObject _decals = _actualModel.transform.Find("Decals").gameObject;
            GameObject _rust03 = _decals.transform.Find("base_abandoned_interior_decals_rust_03").gameObject;
            GameObject.Destroy(_rust03);            
            GameObject _rust06 = _decals.transform.Find("base_abandoned_interior_decals_rust_06").gameObject;
            GameObject.Destroy(_rust06);
            GameObject _rust05 = _decals.transform.Find("base_abandoned_interior_decals_rust_05").gameObject;
            GameObject.Destroy(_rust05);
            
            GameObject _moss03_stay = _decals.transform.Find("base_abandoned_interior_decals_moss_03").gameObject;
            _moss03_stay.name = "base_abandoned_interior_decals_moss_03 (1)";
            _moss03_stay = _decals.transform.Find("base_abandoned_interior_decals_moss_03").gameObject;
            _moss03_stay.name = "base_abandoned_interior_decals_moss_03 (2)";
            _moss03_stay = _decals.transform.Find("base_abandoned_interior_decals_moss_03").gameObject;
            _moss03_stay.name = "base_abandoned_interior_decals_moss_03 (3)";
            _moss03_stay = _decals.transform.Find("base_abandoned_interior_decals_moss_03").gameObject;
            _moss03_stay.name = "base_abandoned_interior_decals_moss_03 (4)";
            GameObject _moss03 = _decals.transform.Find("base_abandoned_interior_decals_moss_03").gameObject;
            GameObject.Destroy(_moss03);

            GameObject _leaking04_stay = _decals.transform.Find("base_abandoned_interior_decals_leaking_04").gameObject;
            _leaking04_stay.name = "base_abandoned_interior_decals_leaking_04 (1)";
            GameObject _leaking04 = _decals.transform.Find("base_abandoned_interior_decals_leaking_04").gameObject;
            GameObject.Destroy(_leaking04);

            GameObject _rust12_stay = _decals.transform.Find("base_abandoned_interior_decals_rust_12").gameObject;
            _rust12_stay.name = "base_abandoned_interior_decals_rust_12 (1)";
            GameObject _rust12 = _decals.transform.Find("base_abandoned_interior_decals_rust_12").gameObject;
            GameObject.Destroy(_rust12);

            GameObject _leaking02_stay = _decals.transform.Find("base_abandoned_interior_decals_leaking_02").gameObject;
            _leaking02_stay.name = "base_abandoned_interior_decals_leaking_02 (1)";
            GameObject _leaking02 = _decals.transform.Find("base_abandoned_interior_decals_leaking_02").gameObject;
            GameObject.Destroy(_leaking02);

            GameObject _moss01 = _decals.transform.Find("base_abandoned_interior_decals_moss_01").gameObject;
            GameObject.Destroy(_moss01);

            GameObject _slots = obj.transform.Find("Slots").gameObject;
            GameObject.Destroy(_slots);

            // Ставим нашу часть базы на нулевые координаты относительно родительского объекта
            _actualModel.transform.localPosition = new Vector3(0f, 0f, 10f);
            _actualModel.transform.eulerAngles = Vector3.zero;
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

