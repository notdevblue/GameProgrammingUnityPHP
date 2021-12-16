using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserMenu : MonoBehaviour
{
    [SerializeField] Button _weaponButton;
    public event Action OnWeaponButtonPressed;
    
    [SerializeField] Button _armorButton;
    public event Action OnArmorButtonPressed;

    [SerializeField] Button _dataButton;
    public event Action OnDataButtonPressed;

    private void Start()
    {
        OnWeaponButtonPressed += () => { };
        OnArmorButtonPressed  += () => { };
        OnDataButtonPressed   += () => { };

        _weaponButton.onClick.AddListener(() => {
            OnWeaponButtonPressed();
        });

        _armorButton.onClick.AddListener(() => {
            OnArmorButtonPressed();
        });

        _dataButton.onClick.AddListener(() => {
            OnDataButtonPressed();
        });
    }
}
