using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePieceCorridorCap
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePieceCorridorCap", "База дегази", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "99b164ac-dfb4-4a14-b305-8666fa227717");
        _clone.ModifyPrefab += obj =>
        {
            GameObject _delete;
            // Удаляем хлам
            //GameObject _delete = obj.transform.Find("Locker(Clone)").gameObject;
            //GameObject.Destroy(_delete);
            //_delete = obj.transform.Find("Bench(Clone)").gameObject;
            //GameObject.Destroy(_delete);
            //_delete = obj.transform.Find("Fabricator(Clone)").gameObject;
            //GameObject.Destroy(_delete);

            // Удаляем остальные части базы
            GameObject _rename = obj.transform.Find("BaseCell").gameObject;
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
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete5";
            _delete = obj.transform.Find("delete5").gameObject;
            GameObject.Destroy(_delete);

            GameObject _slots = obj.transform.Find("Slots").gameObject;
            GameObject.Destroy(_slots);

            // Оставляем только одну часть базы
            GameObject _actualModel = obj.transform.Find("BaseCell").gameObject;
            // Переименовываем в PieceModel
            _actualModel.name = "PieceModel";

            // Ставим нашу часть базы на нулевые координаты относительно родительского объекта
            _actualModel.transform.localPosition = Vector3.zero;
            _actualModel.transform.eulerAngles = Vector3.zero;

            GameObject _addObj = _actualModel.transform.Find("BaseAbandonedCorridorIShapeReinforcementSide").gameObject;
            GameObject _addObj2 = _actualModel.transform.Find("BaseAbandonedCorridorIShape").gameObject;
            GameObject _addObj3 = _actualModel.transform.Find("BaseAbandonedCorridorIShapeInteriorPlanterSide").gameObject;
            GameObject _decals = _actualModel.transform.Find("Decals").gameObject;
            GameObject _debris2 = _actualModel.transform.Find("Debris2").gameObject;
            GameObject _foliage = _actualModel.transform.Find("Foliage").gameObject;
            _decals.transform.parent = _addObj2.transform;
            _debris2.transform.parent = _addObj2.transform;
            _foliage.transform.parent = _addObj2.transform;
            _addObj.transform.localPosition = Vector3.zero;
            _addObj.transform.eulerAngles = Vector3.zero;
            _addObj2.transform.localPosition = Vector3.zero;
            _addObj2.transform.eulerAngles = Vector3.zero;
            _addObj3.transform.localPosition = Vector3.zero;
            _addObj3.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            //_actualModel.transform.Rotate(new Vector3(0,0,10), 2f);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

