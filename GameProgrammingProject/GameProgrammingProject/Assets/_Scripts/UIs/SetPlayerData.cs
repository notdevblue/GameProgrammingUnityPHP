using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerData : MonoBehaviour
{
    [SerializeField] private Text _userDataText;

    /// <summary>
    /// Sets user's data
    /// </summary>
    /// <param name="type">item's type</param>
    /// <param name="name">item's name</param>
    public void Set(string type, string name)
    {
        _userDataText.text = type != "" ? $"{(type == "0" ? "무기" : "방어구")}: {name}" : "아무런 아이탬이 없습니다.";
    }
}
