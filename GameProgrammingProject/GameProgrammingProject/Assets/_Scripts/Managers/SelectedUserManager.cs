using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUserManager : MonoSingleton<SelectedUserManager>
{
    public string _SelectedUserName { get; private set; }
    public string _SelectedUserGold { get; set; }


    public void Deselect()
    {
        _SelectedUserName = null;
    }

    public void Select(string name)
    {
        _SelectedUserName = name;
    }
    
}
