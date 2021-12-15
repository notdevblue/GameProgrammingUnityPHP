using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUserData : MonoBehaviour
{
    [SerializeField] private Text _userDataText;
    [SerializeField] private Button _selectButton;

    // for req
    private string userName;
    private string userGold;

    private void Start()
    {
        _selectButton.onClick.AddListener(() => {
            RequestModule.Instance.Request(new ReqObject[2] { new ReqObject("type", "DATA"), new ReqObject("name", userName) });
        });
    }

    /// <summary>
    /// Sets user's data
    /// </summary>
    /// <param name="name">user's name</param>
    /// <param name="gold">user's gold</param>
    public void Set(string name, string gold)
    {
        userName = name;
        userGold = gold;
        _userDataText.text = $"{name} has {gold} gold";
    }
}
