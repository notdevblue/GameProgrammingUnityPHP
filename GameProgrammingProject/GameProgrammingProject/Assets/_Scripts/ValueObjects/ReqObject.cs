/// <summary>
/// WWWForm 의 field 추가용
/// </summary>
[System.Serializable]
public class ReqObject
{
    public string form;
    public string data;

    public ReqObject(string form, string data)
    {
        this.form = form;
        this.data = data;
    }
}