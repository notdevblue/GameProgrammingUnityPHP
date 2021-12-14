using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestModule : MonoSingleton<RequestModule>
{
    /// <summary>
    /// Called when request sent.
    /// </summary>
    public event Action OnSendWebRequest;

    /// <summary>
    /// Called when response arrived.
    /// </summary>
    public event Action OnWebRequesetArrived;

    private void Awake()
    {
        OnSendWebRequest += () => { };
        OnWebRequesetArrived += () => { };
    }


    /// <summary>
    /// Sends POST request to server (or website).
    /// </summary>
    /// <param name="callback">called when data arrived<br/>NULL when error</param>
    /// <param name="datas">form datas</param>
    /// <param name="url">address of server or website</param>
    public void Request(Action<string> callback = null, ReqObject[] datas = null, string url = "http://172.31.0.224/GameProgramming/Project/Response.php")
    {
        StartCoroutine(ReqSend(callback, datas, url));
    }

    private IEnumerator ReqSend(Action<string> callback, ReqObject[] datas, string url)
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
                callback?.Invoke(req.downloadHandler.text);
                break;

            default:
                Debug.LogError($"RequestModule::Request (Coroutine) > {req.result}\r\n{req.error}");
                callback?.Invoke(null);
                break;
        }

    }
}
