using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePieceMultipurpose
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePieceMultipurpose", "База дегази", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "8f20a08c-c981-4fad-a57b-2de2106b8abf");
        _clone.ModifyPrefab += obj =>
        {
            // Удаляем хлам
            GameObject _delete = obj.transform.Find("Locker(Clone)").gameObject;
            GameObject.Destroy(_delete);
            _delete = obj.transform.Find("Bench(Clone)").gameObject;
            GameObject.Destroy(_delete);
            _delete = obj.transform.Find("Fabricator(Clone)").gameObject;
            GameObject.Destroy(_delete);

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

            // Оставляем только одну часть базы
            GameObject _actualModel = obj.transform.Find("BaseCell(Clone)").gameObject;
            // Переименовываем в PieceModel
            _actualModel.name = "PieceModel";

            // Заменяем живые стены на обычные стены
            //  Стена 1
            GameObject _wall = _actualModel.transform.Find("BaseRoomPlanterSide(Clone)").gameObject;
            _wall.name = "BaseRoomWall1(Clone)";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Стена 2
            _wall = _actualModel.transform.Find("BaseRoomPlanterSide(Clone)").gameObject;
            _wall.name = "BaseRoomWall2(Clone)";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Стена 3
            _wall = _actualModel.transform.Find("BaseRoomPlanterSide(Clone)").gameObject;
            _wall.name = "BaseRoomWall3(Clone)";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Стена 4
            _wall = _actualModel.transform.Find("BaseRoomPlanterSide(Clone)").gameObject;
            _wall.name = "BaseRoomWall4(Clone)";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Сетан 5
            _wall = _actualModel.transform.Find("BaseRoomPlanterSide(Clone)").gameObject;
            _wall.name = "BaseRoomWall5(Clone)";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);
            //  Стена 6
            _wall = _actualModel.transform.Find("BaseRoomPlanterSide(Clone)").gameObject;
            _wall.name = "BaseRoomWall6(Clone)";
            _wall.transform.Find("model3").gameObject.SetActive(false);
            _wall.transform.Find("model1").gameObject.SetActive(true);


            // Ставим нашу часть базы на нулевые координаты относительно родительского объекта
            _actualModel.transform.position = Vector3.zero;
            _actualModel.transform.eulerAngles = Vector3.zero;
            //_actualModel.transform.Rotate(new Vector3(0,0,10), 2f);
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

