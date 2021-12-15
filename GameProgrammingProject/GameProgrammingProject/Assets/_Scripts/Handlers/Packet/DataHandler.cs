using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private void Start() {
        PacketHandler.Instance.AddHandler("DATA", (members) => {

            members.Item1.ForEach((e) => {
                Debug.Log(e);
            });

            members.Item2.ForEach(e => {
                Debug.Log(e);
            });

        });
    }
}
