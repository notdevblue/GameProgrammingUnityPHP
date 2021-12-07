using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Register : MonoBehaviour
{
    public InputField loginIdInput;
    public InputField loginPasswordInput;
    public Dropdown typeMenu;

    public GameObject textPrefab;

    public Transform loginPanel;
    public Transform resultPanel;

    public void btnRegister()
    {
        // StartCoroutine(_Register());
        StartCoroutine(GetData());
    }

    IEnumerator _Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("login_id", loginIdInput.text);
        form.AddField("login_password", loginPasswordInput.text);

        string url = "http://127.0.0.1/GameProgramming/member_1/reg_member.php";

        UnityWebRequest req = UnityWebRequest.Post(url, form);
        
        yield return req.SendWebRequest();

        switch(req.result)
        {
            case UnityWebRequest.Result.ConnectionError:
//            case UnityWebRequest.Result.DataProcessError:
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(req.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(req.downloadHandler.text);
                break;
        }
    }


    IEnumerator GetData()
    {
        WWWForm form = new WWWForm();
        form.AddField("login_id", loginIdInput.text);
        form.AddField("login_password", loginPasswordInput.text);
        form.AddField("type", typeMenu.value + 1);

        string url = "http://127.0.0.1/GameProgramming/member_1/list_member.php";

        UnityWebRequest req = UnityWebRequest.Post(url, form);

        yield return req.SendWebRequest();
        loginPanel.gameObject.SetActive(false);
        resultPanel.gameObject.SetActive(true);

        switch(req.result)
        {
            case UnityWebRequest.Result.Success:
                Debug.Log(req.downloadHandler.text);
                InfoVO vo = JsonUtility.FromJson<InfoVO>(req.downloadHandler.text);
                Debug.Log(vo.info.Count);


                foreach(var item in vo.info)
                {
                    
                    

                    Instantiate(textPrefab, resultPanel).GetComponent<TextObject>().SetData(item.login_id, item.name);
                }
                
                break;
        }
    }

}

[System.Serializable]
public class InfoVO
{
    public List<AccountData> info = new List<AccountData>();

    public InfoVO(List<AccountData> info)
    {
        this.info = info;
    }
}

[System.Serializable]
public class AccountData
{
    public string login_id;
    public string name;

    public AccountData(string id, string name)
    {
        this.login_id = id;
        this.name = name;
    }
}