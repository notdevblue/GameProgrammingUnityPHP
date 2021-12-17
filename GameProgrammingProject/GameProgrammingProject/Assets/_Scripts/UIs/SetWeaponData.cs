using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWeaponData : MonoBehaviour
{
    [SerializeField] private Text _weaponDataText;
    [SerializeField] private Button _selectButton;

    // for req
    private string currentWeapon;

    private void Start()
    {
        _selectButton?.onClick.AddListener(() => {
            RequestModule.Instance.Request(new ReqObject[] { new ReqObject("type", "BUY"), new ReqObject("name", SelectedUserManager.Instance._SelectedUserName), new ReqObject("itemId", currentWeapon) });
        });
    }

    /// <summary>
    /// Sets user's data
    /// </summary>
    /// <param name="weapon">weapon</param>
    /// <param name="gold">weapon's price</param>
    public void Set(string weapon, string gold)
    {
        currentWeapon = weapon;
        _weaponDataText.text = $"{weapon}, ${gold}";
    }
}
