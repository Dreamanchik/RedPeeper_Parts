using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class CleanFoundation
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("CleanFoundation", "Фундамент", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "a1e2f322-7080-48ca-8eaf-a05afff8585d");
        _clone.ModifyPrefab += obj =>
        {
            GameObject _delete;
            // Оставляем только одну часть базы
            GameObject _actualModel = obj.transform.Find("BaseCell(Clone)").gameObject;
            // Переименовываем в PieceModel
            _actualModel.name = "PieceModel";

            // Удаляем остальные части базы
            GameObject _rename = obj.transform.Find("BaseCell(Clone)").gameObject;
            _rename.name = "delete1";
            _delete = obj.transform.Find("delete1").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell(Clone)").gameObject;
            _rename.name = "delete2";
            _delete = obj.transform.Find("delete2").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell(Clone)").gameObject;
            _rename.name = "delete3";
            _delete = obj.transform.Find("delete3").gameObject;
            GameObject.Destroy(_delete);
            _rename = obj.transform.Find("BaseCell(Clone)").gameObject;
            _rename.name = "delete4";
            _delete = obj.transform.Find("delete4").gameObject;
            GameObject.Destroy(_delete);
            _delete = obj.transform.Find("GameObject").gameObject;
            GameObject.Destroy( _delete);

            // Удаляю ящик
            GameObject locker = obj.transform.Find("Locker(Clone)").gameObject;
            GameObject.Destroy(locker);
            // Удаляю изготовитель
            GameObject fabricator = obj.transform.Find("Fabricator(Clone)").gameObject;
            GameObject.Destroy(fabricator);
            // Удаляю модификационный
            GameObject workbench = obj.transform.Find("Workbench(Clone)").gameObject;
            GameObject.Destroy(workbench);
            // Удаляю кресло
            GameObject bench = obj.transform.Find("Bench(Clone)").gameObject;
            GameObject.Destroy(bench);

            // Ставим нашу часть базы на нулевые координаты относительно родительского объекта
            _actualModel.transform.localPosition = Vector3.zero;
            _actualModel.transform.eulerAngles = Vector3.zero;
            //_actualModel.transform.Rotate(new Vector3(0,0,10), 2f);

        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

