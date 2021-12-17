using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupHandler : MonoBehaviour
{
    System.Exception _unknownCallbackException = new System.Exception("Unknown callback event.");

    [SerializeField] private Popup popupPanel;

    void Start()
    {
        PacketHandler.Instance.AddHandler("POPUP", (members) => {

            if(members.Item2.Count > 1)
            {
                switch(members.Item2[1]) 
                {
                    case "RETURNTOMAIN":
                        popupPanel.Show(members.Item2[0], () => {
                            UIManager.Instance.ReturnToMain();
                        });
                        break;

                    default:
                        throw _unknownCallbackException;
                }
            }
            else
            {
                popupPanel.Show(members.Item2[0]);
            }
        });
    }
}
