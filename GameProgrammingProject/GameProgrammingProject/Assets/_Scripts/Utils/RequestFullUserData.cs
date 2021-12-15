using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestFullUserData : MonoBehaviour
{
    private void Start()
    {
        RequestModule.Instance.Request(new ReqObject[1] { new ReqObject("type", "FULLDATA") });
    }
}
