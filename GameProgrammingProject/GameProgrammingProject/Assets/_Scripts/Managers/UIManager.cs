using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject userPanelObject;
    [SerializeField] private GameObject selectPanelObject;
    [SerializeField] private GameObject itemDataPanelObject;
    [SerializeField] private GameObject dataPanelObject;

    [SerializeField] private Text _itemDataText;
    [SerializeField] private Text _headerUserDataText;
    [SerializeField] private Button _backButton;

    private Stack<GameObject> _panelQueue;


    private void Start()
    {
        _panelQueue   = new Stack<GameObject>();

        _panelQueue.Push(userPanelObject);
        userPanelObject.SetActive(true);

        _backButton.onClick.AddListener(() => {
            Close();
        });
    }

    public void Open(GameObject panel)
    {
        _panelQueue.Peek().SetActive(false);
        _panelQueue.Push(panel);
        panel.SetActive(true);
    }

    public void OpenSelectPanel()
    {
        Open(selectPanelObject);
    }

    public void OpenDataPanel()
    {
        Open(dataPanelObject);
    }

    public void OpenItemDataPanel()
    {
        SetItemDataText(SelectedUserManager.Instance._SelectedUserName, SelectedUserManager.Instance._SelectedUserGold);
        Open(itemDataPanelObject);
    }

    public void SetUserHeaderText(string name)
    {
        _headerUserDataText.text = $"{name}'s Data";
    }

    public void SetItemDataText(string name, string gold) 
    {
        _itemDataText.text = $"{name} has {gold} gold";
    }

    public bool Close()
    {
        if(_panelQueue.Count <= 1) { // 이 이상 닫으면 안됨
            return false;
        }

        Debug.Log("A");

        _panelQueue.Pop().SetActive(false);
        _panelQueue.Peek().SetActive(true);
        return true;
    }

    public void ReturnToMain()
    {
        while(Close());
    }
}