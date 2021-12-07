using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObject : MonoBehaviour
{
    public Text name;
    public Text type;

    public void SetData(string name, string type)
    {
        this.name.text = name;
        this.type.text = type;
    }
}
