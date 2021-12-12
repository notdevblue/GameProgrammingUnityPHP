using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestModule : MonoBehaviour
{
    /// <summary>
    /// Request 전송 시 호출
    /// </summary>
    public event Action OnSendWebRequest;

    /// <summary>
    /// 서버의 Response 도착 시 호출
    /// </summary>
    public event Action OnWebRequesetArrived;

    private void Awake()
    {
        OnSendWebRequest += () => { };
        OnWebRequesetArrived += () => { };
    }



    IEnumerator Request(ReqObject[] datas = null, string url = "http://172.31.0.224/GameProgramming/Project/Response.php")
    {
        // WWWForm 
        WWWForm form = new WWWForm();
        if(datas != null)
        {
            try {
                datas.ToList().ForEach(e => { // Adds form
                    form.AddField(e.form, e.data);
                });
            } catch (Exception ex) { // exception
                Debug.LogError(ex);
                yield break;
            }
        }

        UnityWebRequest req = UnityWebRequest.Post(url, form);

        OnSendWebRequest();
        yield return req.SendWebRequest();
        OnWebRequesetArrived();

        switch(req.result)
        {
            case UnityWebRequest.Result.Success:
                string res = req.downloadHandler.text;
                Debug.Log(res);
                break;

            default:
                Debug.LogError(req.error);
                break;
        }

    }
}
