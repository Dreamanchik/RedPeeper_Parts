using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePieceTCorridorGlass
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePieceTCorridorGlass", "База дегази", "У тебя не должно быть доступа к этому...");
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
            _delete = obj.transform.Find("delete3").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete4";
            _delete = obj.transform.Find("delete4").gameObject;
            GameObject.Destroy(_delete);

            // Оставляем только одну часть базы
            GameObject _actualModel = obj.transform.Find("BaseCell").gameObject;
            // Переименовываем в PieceModel
            _actualModel.name = "PieceModel";

            // Удаляем остальные части базы
            _rename = obj.transform.Find("BaseCell").gameObject;
            _rename.name = "delete5";
            _delete = obj.transform.Find("delete5").gameObject;
            GameObject.Destroy(_delete);

            GameObject _slots = obj.transform.Find("Slots").gameObject;
            GameObject.Destroy(_slots);
            
            GameObject _deleteSpotlight = _actualModel.transform.Find("Spotlight_rusted").gameObject;
            GameObject.Destroy(_deleteSpotlight);

            GameObject _deleteLadder = _actualModel.transform.Find("BaseCorridorLadderBottom/logic").gameObject;
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

