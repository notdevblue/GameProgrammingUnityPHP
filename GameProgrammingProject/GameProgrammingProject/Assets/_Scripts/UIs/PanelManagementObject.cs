using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagementObject : MonoBehaviour, IMenuPanel
{
    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
