using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField] private GameObject _userDataPrefab;
    [SerializeField] private GameObject _weaponDataPrefab;
    [SerializeField] private GameObject _userItemDataPrefab;
    [SerializeField] private Transform _userDataObjectParent;
    [SerializeField] private Transform _itemDataObjectParent;
    [SerializeField] private Transform _userItemDataObjectParent;

    private void Start()
    {
        if (_userDataPrefab   == null) throw new System.Exception("DataHandler::Start() > _userDataPrefab is null.");
        if (_weaponDataPrefab == null) throw new System.Exception("DataHandler::Start() > _weaponDataPrefab is null.");

        PacketHandler.Instance.AddHandler("DATA", (members) => {
            Instantiate(_userDataPrefab, _userDataObjectParent).GetComponent<SetUserData>().Set(members.Item2[0], members.Item2[1]);
        });

        PacketHandler.Instance.AddHandler("WEAPONDATA", (members) => {
            Instantiate(_weaponDataPrefab, _itemDataObjectParent).GetComponent<SetWeaponData>().Set(members.Item2[0], members.Item2[1]);
        });

        PacketHandler.Instance.AddHandler("USERITEM", (members) => {
            Instantiate(_userItemDataPrefab, _userItemDataObjectParent).GetComponent<SetPlayerData>().Set(members.Item2[0], members.Item2[1]);
        });
    }

    
}
