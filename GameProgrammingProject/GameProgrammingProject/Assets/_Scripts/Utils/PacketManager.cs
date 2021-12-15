using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketManager : MonoSingleton<PacketManager>
{
    /// <summary>
    /// Called when parse is ended<br/>
    /// OnHandlePacket(type, (name of members, data of members));
    /// </summary>
    public event Action<string, (List<string>, List<string>)> OnHandlePacket;


    #region DEFINE

    const char TYPE = '#';
    const char MEMBER = '$';
    const char VALUE = '=';
    const char TERMINATOR = ';';

    #endregion

    Exception _invalidPacketException = new Exception("Packet is invalid");

    private void Start()
    {
        OnHandlePacket += (a, b) => { };
        Parse();
    }

    public void Parse()
    {
        RequestModule.Instance.Request((data) => { // TODO : Debug lambda
            if (data == null) { Debug.LogWarning("PacketManager::Parse() > handled data is null, quitting."); return; }
            ParsePacket(data);
        });
    }

    /// <summary>
    /// Parses Packet
    /// </summary>
    /// <param name="data">response</param>
    private void ParsePacket(string data)
    {
        if (data[0] == TYPE)
        {
            #region TYPE

            int typeEndIdx = data.IndexOf(TYPE, 1);

            if (typeEndIdx <= 0) throw _invalidPacketException;

            string type = data.Substring(1, typeEndIdx - 1);

            Debug.Log("type is: " + type);

            #endregion

            if (data.Length <= typeEndIdx + 1)
            {
                OnHandlePacket(type, (null, null));
                return;
            } // For packet which only contains type.

            #region Member Group

            if (data[typeEndIdx + 1] != MEMBER) throw _invalidPacketException;

            int memberStartIdx = typeEndIdx + 1;
            int memberEndIdx = data.IndexOf(TERMINATOR, memberStartIdx + 1);

            if (memberEndIdx <= memberStartIdx) throw _invalidPacketException;

            string member = data.Substring(memberStartIdx + 1, memberEndIdx - memberStartIdx - 1);

            #endregion

            OnHandlePacket(type, ParseMember(member));
        }
        else
        {
            throw _invalidPacketException;
        }
    }


    private (List<string>, List<string>) ParseMember(string data)
    {
        string[] members   = data.Split(MEMBER);
        string[] temp      = new string[2];
        List<string> name  = new List<string>();
        List<string> value = new List<string>();

        for (int i = 0; i < members.Length; ++i)
        {
            temp = members[i].Split(VALUE);
            name.Add(temp[0]);
            value.Add(temp[1]);
        }

        return (name, value);
    }

}
