using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject userPanelObject;
    [SerializeField] private GameObject selectPanelObject;
    [SerializeField] private GameObject dataPanelObject;
    [SerializeField] private GameObject itemDataPanelObject;

    private IMenuPanel userPanel;
    private IMenuPanel selectPanel;
    private IMenuPanel dataPanel;
    private IMenuPanel itemDataPanel;

    private Queue<IMenuPanel> _panelQueue;


    private void Start()
    {
        _panelQueue   = new Queue<IMenuPanel>();
        userPanel     = userPanelObject.GetComponent<IMenuPanel>();
        selectPanel   = selectPanelObject.GetComponent<IMenuPanel>();
        dataPanel     = dataPanelObject.GetComponent<IMenuPanel>();
        itemDataPanel = itemDataPanelObject.GetComponent<IMenuPanel>();

        _panelQueue.Enqueue(userPanel);
        userPanel.Enable();
    }

    public void Open(IMenuPanel panel)
    {
        _panelQueue.Peek().Disable();
        _panelQueue.Enqueue(panel);
        panel.Enable();
    }

    public void OpenSelectPanel()
    {
        Open(selectPanel);
    }

    public void OpenDataPanel()
    {
        Open(dataPanel);
    }

    public void OpenItemDataPanel()
    {
        Open(itemDataPanel);
    }

    public void Close()
    {
        if(_panelQueue.Peek() == userPanel) { // 이 이상 닫으면 안됨
            return;
        }

        _panelQueue.Dequeue().Disable();
        _panelQueue.Peek().Enable();
    }
}
