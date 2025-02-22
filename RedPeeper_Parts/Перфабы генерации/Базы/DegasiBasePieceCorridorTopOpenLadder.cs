using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePieceCorridorTopOpenLadder
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePieceCorridorTopOpenLadder", "База дегази", "У тебя не должно быть доступа к этому...");
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
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete3";
            GameObject _narrower1 = _rename.transform.Find("BaseAbandonedCorridorXShape/models/bendCap_zp_narrower (1)").gameObject;
            GameObject _narrower2 = _rename.transform.Find("BaseAbandonedCorridorXShape/models/bendCap_zp_narrower (2)").gameObject;

            // Оставляем только одну часть базы
            GameObject _actualModel = obj.transform.Find("BaseCell").gameObject;
            // Переименовываем в PieceModel
            _actualModel.name = "PieceModel";

            // Делаю бэкфлип
            _narrower1.transform.parent = _actualModel.transform;
            _narrower2.transform.parent = _actualModel.transform;
            _delete = obj.transform.Find("delete3").gameObject;
            GameObject.Destroy(_delete);

            // Удаляем остальные части базы
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

            _delete = _actualModel.transform.Find("BaseCorridorLadderTop/logic").gameObject;
            GameObject.Destroy(_delete);

            _delete = _actualModel.transform.Find("Spotlight_rusted").gameObject;
            GameObject.Destroy(_delete);

            _delete = _actualModel.transform.Find("IslandsPDABase1Marooned(Placeholder)").gameObject;
            GameObject.Destroy(_delete);

            GameObject _slots = obj.transform.Find("Slots").gameObject;
            GameObject.Destroy(_slots);

            // Ставим нашу часть базы на нулевые координаты относительно родительского объекта
            _actualModel.transform.localPosition = new Vector3(0f, 0f, 15f);
            _actualModel.transform.eulerAngles = Vector3.zero;
            //_actualModel.transform.Rotate(new Vector3(0,0,10), 2f);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

