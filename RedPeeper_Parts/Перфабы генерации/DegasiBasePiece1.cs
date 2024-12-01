using Nautilus.Assets;
using Nautilus.Assets.PrefabTemplates;
using UnityEngine;

public class DegasiBasePiece1
{
    public static PrefabInfo Info { get; set; } = PrefabInfo.WithTechType("DegasiBasePiece1", "База дегази", "У тебя не должно быть доступа к этому...");
    public static void Register()
    {
        CustomPrefab _prefab = new CustomPrefab(Info);
        CloneTemplate _clone = new CloneTemplate(Info, "2921736c-c898-4213-9615-ea1a72e28178");
        _clone.ModifyPrefab += obj =>
        {
            GameObject _slots = obj.transform.Find("Slots").gameObject;
            UnityEngine.Object.Destroy(_slots);
            GameObject _model = obj.transform.Find("Culling").gameObject;

            //GameObject[] toRename = new GameObject[]
            //{
            //    _model.transform.parent.Find("BaseCell").gameObject,
            //    //LifePodSeat1Model.transform.parent.Find("interior").gameObject,
            //    //obj.transform.Find("LOD").gameObject
            //};

            /*foreach (var gameObject in toRename)
            {
                UnityEngine.Object.Destroy(gameObject);
            };*/
            GameObject _actualModel = _model.transform.Find("BaseCell").gameObject;
            _actualModel.transform.parent = _actualModel.transform.parent.parent;

            /*int _objects1 = 14;
            while (_objects1 > 0)
            {
                GameObject _delete = obj.transform.Find("BaseCell").gameObject;
                UnityEngine.Object.Destroy(_delete);
                _objects1--;
            }*/
            //GameObject _deleteModel = obj.transform.Find("bed_01_immune(Clone)").gameObject;
            //GameObject _ShitModel = _actualModel.transform.parent.transform.Find("bed_01_immune(Clone)").gameObject;
            //Object.Destroy(_deleteModel);
            //_deleteModel.transform.localScale = new Vector3(2, 2, 2);
            //GameObject _delete = obj.transform.Find("submarine_locker_04_open(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("Starship_work_desk_01_empty(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("Starship_work_chair_02(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("JellyPDARoom2Desk(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("submarine_locker_04_open(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("Starship_work_desk_01_empty(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("Starship_work_desk_01_empty(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //GameObject _delete = obj.transform.parent.Find("Starship_work_chair_02(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("Starship_work_chair_02(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("JellyPDARoom1Desk(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("JellyPDARoom1Locker(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("JellyPDAObservatory(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("JellyPDABrokenCorridor(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            //_delete = obj.transform.Find("JellyPDAExterior(Clone)").gameObject;
            //UnityEngine.Object.Destroy(_delete);
            UnityEngine.Object.Destroy(_model);
            _actualModel.transform.position = Vector3.zero;
        };
        _prefab.SetGameObject(_clone);

        _prefab.Register();
    }
}

