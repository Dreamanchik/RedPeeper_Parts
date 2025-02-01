using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePieceMultipurpose
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePieceMultipurpose", "База дегази", "У тебя не должно быть доступа к этому...");
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

            // Заменяем живые стены на обычные стены
            //  Стена 1
            GameObject _wall = _actualModel.transform.Find("BaseAbandonedRoomPlanterSide").gameObject;
            _wall.name = "BaseRoomWall1";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Стена 2
            _wall = _actualModel.transform.Find("BaseAbandonedRoomPlanterSide").gameObject;
            _wall.name = "BaseRoomWall2";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Стена 3
            _wall = _actualModel.transform.Find("BaseAbandonedRoomPlanterSide").gameObject;
            _wall.name = "BaseRoomWall3";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Стена 4
            _wall = _actualModel.transform.Find("BaseAbandonedRoomPlanterSide").gameObject;
            _wall.name = "BaseRoomWall4";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Сетан 5
            _wall = _actualModel.transform.Find("BaseAbandonedRoomPlanterSide").gameObject;
            _wall.name = "BaseRoomWall5";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);

            GameObject _slots = obj.transform.Find("Slots").gameObject;
            GameObject.Destroy(_slots);

            GameObject _purpleKey = _actualModel.transform.Find("Precursor_PurpleKey(Placeholder)").gameObject;
            GameObject.Destroy(_purpleKey);

            GameObject _workDesk = _actualModel.transform.Find("Starship_work_desk_01(Placeholder)").gameObject;
            GameObject.Destroy(_workDesk);

            GameObject _islandsPDA = _actualModel.transform.Find("IslandsPDABase1PrecursorKey(Placeholder)").gameObject;
            GameObject.Destroy(_islandsPDA);
            
            GameObject _foliage = _actualModel.transform.Find("Foliage").gameObject;
            GameObject.Destroy(_foliage);

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
            _actualModel.transform.localPosition = Vector3.zero;
            _actualModel.transform.eulerAngles = Vector3.zero;
            //_actualModel.transform.Rotate(new Vector3(0,0,10), 2f);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

