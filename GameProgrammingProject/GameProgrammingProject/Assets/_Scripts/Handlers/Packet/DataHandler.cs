using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField] private GameObject _userDataPrefab;
    [SerializeField] private Transform _userDataObjectParent;
    [SerializeField] private Transform _itemDataObjectParent;

    private void Start()
    {
        if(_userDataPrefab == null) throw new System.Exception("DataHandler::Start() > _userDataPrefab is null.");

        PacketHandler.Instance.AddHandler("DATA", (members) => {
            // _userDataObjectParent.GetComponentsInChildren<SetUserData>()?.ToList().ForEach(e => { Destroy(e.gameObject); });
            Instantiate(_userDataPrefab, _userDataObjectParent).GetComponent<SetUserData>().Set(members.Item2[0], members.Item2[1]);
        });

        PacketHandler.Instance.AddHandler("WEAPONDATA", (members) => {
            // _itemDataObjectParent.GetComponentsInChildren<SetWeaponData>()?.ToList().ForEach(e => { Destroy(e.gameObject); });
            Instantiate(_itemDataObjectParent, _itemDataObjectParent).GetComponent<SetWeaponData>().Set(members.Item2[0], members.Item2[1]);
        });


    }

    
}
