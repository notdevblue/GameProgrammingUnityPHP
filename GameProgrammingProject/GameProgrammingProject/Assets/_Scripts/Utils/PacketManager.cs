using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketManager : MonoBehaviour
{
    #region DEFINE

    const char TYPE = '#';
    const char MEMBER = '$';
    const char VALUE = '=';
    const char TERMINATOR = ';';

    #endregion

    Exception _invalidPacketException = new Exception("Packet is invalid");

    private void Start()
    {
        Parse();
    }

    public Dictionary<string, Action<string>> _packetHandlerDictionary = new Dictionary<string, Action<string>>();

    public void Parse()
    {
        RequestModule.Instance.Request((data) => { // TODO : Debug lambda
            if (data == null) { Debug.LogWarning("PacketManager::Parse() > handled data is null, quitting."); return; }

            if(data[0] == TYPE)
            {
                #region TYPE

                int typeEndIdx = data.IndexOf(TYPE, 1);

                if (typeEndIdx <= 0) throw _invalidPacketException;

                string type = data.Substring(1, typeEndIdx - 1);

                Debug.Log("type is: " + type);
                
                #endregion

                if(data.Length <= typeEndIdx + 1) return; // Packet contains only type.

                #region Member Group

                if(data[typeEndIdx + 1] != MEMBER) throw _invalidPacketException;

                int memberStartIdx = typeEndIdx + 1;
                int memberEndIdx = data.IndexOf(TERMINATOR, memberStartIdx + 1);

                if(memberEndIdx <= memberStartIdx) throw _invalidPacketException;

                string member = data.Substring(memberStartIdx + 1, memberEndIdx - memberStartIdx - 1);
                Debug.Log(member);

                #endregion

            }
            else 
            {
                throw _invalidPacketException;
            }

        });
    }
}
