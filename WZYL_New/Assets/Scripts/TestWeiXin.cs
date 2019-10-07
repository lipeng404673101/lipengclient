using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public struct WxUserInfo
{
    string openid;
    string nickname;
    int sex;
    string province;
    string city;
    string country;
    string headimgurl;
    string unionid;
}

public delegate void OnWeiXinLoginSuccess(ref WxUserInfo userInfo);
/// <summary>
///  对象名必为 “JavaCallBack”
/// </summary>
public class TestWeiXin : MonoBehaviour {

    // Use this for initialization
    StringBuilder logString  = new StringBuilder();

    public OnWeiXinLoginSuccess EventWeiXinLogin { get; set; }
    void Start () {
        DontDestroyOnLoad(GameObject.Find("JavaCallBack"));
    }

   
	
	// Update is called once per frame
	void Update () {
		
	}

    public static AndroidJavaObject GetCurrentAndroidJavaObject()                //要有这个AndroidJavaObject才能Call  
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        return jc.GetStatic<AndroidJavaObject>("currentActivity");
    }

    public static void CallSdkApi(string apiName, params object[] args)             //没有返回值的Call  
    {
        
        AndroidJavaObject jo = GetCurrentAndroidJavaObject();
        jo.Call(apiName, args);
    }

    public static T CallSdkApiReturn<T>(string apiName, params object[] args)          //模板只是返回参数类型不同  
    {

        AndroidJavaObject jo = GetCurrentAndroidJavaObject();
        return jo.Call<T>(apiName, args);
    }

    public void OnWeiXinLoginReq(string msg)
    {
        logString.Append(msg + "\n");
        Debug.Log("aaaaaaaaaaaaaaaaa " + msg);       
    }

    IEnumerator RequestWeixinToken(string url)
    {
        using (WWW www = new WWW(url))
        {
            Debug.Log("XXXXXXXXX" + url);
            yield return www;
            TokenInfo ti = JsonUtility.FromJson<TokenInfo>(www.text);

            //string reqUrl = string.Format(https://api.weixin.qq.com/sns/oauth2/access_token?);
            WWWForm wf = new WWWForm();
            wf.AddField("openid", ti.openid);
            wf.AddField("access_token", ti.access_token);
            StartCoroutine(RequestWeiXinUserInfo("https://api.weixin.qq.com/sns/userinfo", wf));
        }
    }

    struct TokenInfo
    {
        public string access_token;
        public string expires_in;
        public string refresh_token;
        public string openid;
        public string scope;
        public string unionid;
    }
    IEnumerator RequestWeiXinUserInfo(string url,WWWForm wf)
    {
        using (WWW www = new WWW(url, wf))
        {
            yield return www;
            Debug.Log(www.text);
            WxUserInfo ti = JsonUtility.FromJson<WxUserInfo>(www.text);
            if (null != EventWeiXinLogin) EventWeiXinLogin(ref ti);
        }
    }

    void json_AcToken(string msg)
    {
        // logString.Append(msg + "\n");
         Debug.Log(msg);
        StartCoroutine(RequestWeixinToken(msg));
    }

    void json_UserInfo(string msg)
    {
        logString.Append(msg + "\n");
        Debug.Log(msg);
    }

    //private void OnGUI()
    //{
    //    if (logString.Length > 0)
    //    {
    //        GUI.TextArea(new Rect(new Vector2(200, 150), new Vector2(600, 300)), logString.ToString());
    //    }
    //}

    
//     public void OnButton()
//     {
//         logString.Append("DDDDDDDDDDDDDDDDDDD /n");
//         AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//         AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
//         jo.Call("SdkLogin");
//     }
}
