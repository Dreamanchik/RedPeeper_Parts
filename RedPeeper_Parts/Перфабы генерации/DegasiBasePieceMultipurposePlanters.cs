using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePieceMultipurposePlanters
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePieceMultipurposePlanters", "База дегази", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "99b164ac-dfb4-4a14-b305-8666fa227717");
        _clone.ModifyPrefab += obj =>
        {
            GameObject _delete;
            // Оставляем только одну часть базы
            GameObject _actualModel = obj.transform.Find("BaseCell").gameObject;
            // Переименовываем в PieceModel
            _actualModel.name = "PieceModel";
            // Берём маленький коридор
            GameObject _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "PieceModel2";

            // Удаляем остальные части базы
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete1";
            _delete = obj.transform.Find("delete1").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete2";
            _delete = obj.transform.Find("delete2").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete3";
            _delete = obj.transform.Find("delete3").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete4";
            _delete = obj.transform.Find("delete4").gameObject;
            GameObject.Destroy(_delete);

            GameObject _slots = obj.transform.Find("Slots").gameObject;
            GameObject.Destroy(_slots);

            GameObject _purpleKey = _actualModel.transform.Find("Precursor_PurpleKey(Placeholder)").gameObject;
            GameObject.Destroy(_purpleKey);

            GameObject _workDesk = _actualModel.transform.Find("Starship_work_desk_01(Placeholder)").gameObject;
            GameObject.Destroy(_workDesk);

            GameObject _islandsPDA = _actualModel.transform.Find("IslandsPDABase1PrecursorKey(Placeholder)").gameObject;
            GameObject.Destroy(_islandsPDA);

            GameObject _mossDecal = _actualModel.transform.Find("Decals/base_abandoned_interior_decals_moss_01").gameObject;
            _mossDecal.name = "base_abandoned_interior_decals_moss_01 (1)";

            GameObject _deleteMossDecal = _actualModel.transform.Find("Decals/base_abandoned_interior_decals_moss_01").gameObject;
            GameObject.Destroy(_deleteMossDecal);

            GameObject _deleteRustDecal = _actualModel.transform.Find("Decals/base_abandoned_interior_decals_rust_09").gameObject;
            GameObject.Destroy(_deleteRustDecal);

            GameObject _debris = _actualModel.transform.Find("Debris").gameObject;
            GameObject.Destroy(_debris);

            GameObject _deleteSpotlight = obj.transform.Find("PieceModel2/Spotlight_rusted").gameObject;
            GameObject.Destroy(_deleteSpotlight);


            // Ставим нашу часть базы на нулевые координаты относительно родительского объекта
            _actualModel.transform.localPosition = new Vector3(0f, -2.5f, 15f);
            _actualModel.transform.eulerAngles = Vector3.zero;
            //_actualModel.transform.Rotate(new Vector3(0,0,10), 2f);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

