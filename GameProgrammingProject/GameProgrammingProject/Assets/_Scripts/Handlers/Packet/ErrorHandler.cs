using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorHandler : MonoBehaviour
{
    private void Start()
    {
        PacketHandler.Instance.AddHandler("ERR", data => {
            throw new System.Exception($"Exception arrived from server > {data.Item2[0]}");
        });
    }
}
