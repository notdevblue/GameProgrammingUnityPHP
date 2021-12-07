using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



[Serializable]
public class JsonInfo
{
    public string login_id;
    public string passwd;
}

[Serializable]
public class Data
{
    public bool result;
    public JsonInfo[] jsonInfo;
}

public class JsonCnt : MonoBehaviour
{
    public Text[] loginIds = new Text[0];
    public Text[] passwords = new Text[0];


    public void setData()
    {
        StartCoroutine(setWWWURL());
    }


    IEnumerator setWWWURL()
    {
        WWWForm form = new WWWForm();
        // form.AddField("id", userId + "_" + 0);

        string URL = "http://127.0.0.1/login_process.php";

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

        switch (www.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("error_1:" + www.error);
                break;

            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("error_2:" + www.error);
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log(www.downloadHandler.text);

                JsonInfo jsoninfo = JsonUtility.FromJson<JsonInfo>(www.downloadHandler.text);
                Data d = new Data();
                d = JsonUtility.FromJson<Data>(www.downloadHandler.text);

                Debug.Log(d.jsonInfo[0].login_id);

                for (int i = 0; i < 10; ++i)
                {
                    loginIds[i].text = d.jsonInfo[i].login_id;
                    passwords[i].text = d.jsonInfo[i].passwd;
                }

                break;
        }

    }






    // Update is called once per frame
    void Update()
    {

    }
}