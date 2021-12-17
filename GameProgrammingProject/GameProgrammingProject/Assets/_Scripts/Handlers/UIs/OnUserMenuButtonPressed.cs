using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUserMenuButtonPressed : MonoBehaviour
{
    UserMenu _userMenu;

    void Start()
    {
        _userMenu = GetComponent<UserMenu>();

        _userMenu.OnArmorButtonPressed += () => {
            RequestModule.Instance.Request(new ReqObject[] { new ReqObject("type", "GETARMOR") });
            UIManager.Instance.OpenItemDataPanel();
        };

        _userMenu.OnWeaponButtonPressed += () => {
            RequestModule.Instance.Request(new ReqObject[] { new ReqObject("type", "GETWEAPON") });
            UIManager.Instance.OpenItemDataPanel();
        };

        _userMenu.OnDataButtonPressed += () => {
            RequestModule.Instance.Request(new ReqObject[] { new ReqObject("type", "USERITEM"), new ReqObject("id", SelectedUserManager.Instance._SelectedUserName) });
        };
    }
}
