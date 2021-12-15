using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField] private GameObject _userDataPrefab;
    [SerializeField] private Transform _userDataObjectParent;

    private void Start()
    {
        if(_userDataPrefab == null) throw new System.Exception("DataHandler::Start() > _userDataPrefab is null.");

        PacketHandler.Instance.AddHandler("DATA", (members) => {
            Instantiate(_userDataPrefab, _userDataObjectParent).GetComponent<SetUserData>().Set(members.Item2[0], members.Item2[1]);
        });
    }
}
