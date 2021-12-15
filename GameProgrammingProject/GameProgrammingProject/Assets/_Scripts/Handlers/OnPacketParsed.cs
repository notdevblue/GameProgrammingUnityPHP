using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPacketParsed : MonoBehaviour
{
    private void Start()
    {
        PacketManager.Instance.OnHandlePacket += PacketHandler.Instance.Handle;
    }
}
