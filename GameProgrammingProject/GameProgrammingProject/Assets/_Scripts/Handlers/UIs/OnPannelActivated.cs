using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class OnPannelActivated : MonoBehaviour
{
    [SerializeField] private GameObject rowObject;

    private void OnEnable()
    {
        Transform[] objs = rowObject.GetComponentsInChildren<Transform>();

        for (int i = 1; i < objs.Length; ++i)
        {
            Destroy(objs[i].gameObject);
        }
    }
}
