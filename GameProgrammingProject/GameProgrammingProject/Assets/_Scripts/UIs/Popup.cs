using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private Text popupText;
    private event System.Action callback;

    public void Show(string text, System.Action closeCallback = null, float autoCloseTime = 3.0f, bool autoClose = true)
    {
        callback = closeCallback;
        popupText.text = text;
        gameObject.SetActive(true);

        if(autoClose)
            Invoke(nameof(Close), autoCloseTime);
    }

    public void Close()
    {
        callback?.Invoke();
        gameObject.SetActive(false);
    }
}
