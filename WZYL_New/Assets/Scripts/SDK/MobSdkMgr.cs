using cn.sharesdk.unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSdkMgr : MonoBehaviour {

    private ShareSDK ssdk;
    private static MobSdkMgr ms_Instance = null;
    public static MobSdkMgr Instance
    {
        get
        {
            return ms_Instance;
        }
    }
    void Awake()
    {
        ms_Instance = this;
    }
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        ssdk = this.transform.GetComponent<ShareSDK>();
        ssdk.authHandler = OnAuthResultHandler;
        ssdk.showUserHandler = OnGetUserInfoResultHandler;
        ssdk.getFriendsHandler = OnGetFriendsResultHandler;
        ssdk.followFriendHandler = OnFollowFriendResultHandler;
        ssdk.shareHandler = OnShareResultHandler;
    }
    public void TT()
    {
        if (ssdk.Authorize(cn.sharesdk.unity3d.PlatformType.WeChat) != 0)
        {
            ssdk.GetUserInfo(cn.sharesdk.unity3d.PlatformType.WeChat);
        }
    }

    public void OnAuthResultHandler(int reqID, cn.sharesdk.unity3d.ResponseState state, cn.sharesdk.unity3d.PlatformType type, Hashtable result)
    {
        if (state == ResponseState.Success)
        {
            if (result.Count > 0)
            {
                print("authorize success !" + "Platform :" + type + "result:" + MiniJSON.jsonEncode(result));
            }
            else
            {
                print("authorize success !" + "Platform :" + type);
            }
        }
        else if (state == ResponseState.Fail)
        {
#if UNITY_ANDROID
            print("fail! throwable stack = " + result["stack"] + "; error msg = " + result["msg"]);
#elif UNITY_IPHONE
			print ("fail! error code = " + result["error_code"] + "; error msg = " + result["error_msg"]);
#endif
        }
        else if (state == ResponseState.Cancel)
        {
            print("cancel !");
        }
    }

    public void OnGetUserInfoResultHandler(int reqID, cn.sharesdk.unity3d.ResponseState state, cn.sharesdk.unity3d.PlatformType type, Hashtable result)
    {
        Debug.Log("jieshoudaoweixinhuidiao-----");
        Debug.Log("接收到微信回调-------");
        Debug.Log(MiniJSON.jsonEncode(result));

        JsonData data = JsonMapper.ToObject(MiniJSON.jsonEncode(result));
        SDKLoginResult lr = new SDKLoginResult();
        if (state == ResponseState.Success)
        {
            Debug.Log("get user info result :");
            Debug.Log(MiniJSON.jsonEncode(result));
            Debug.Log("Get userInfo success !Platform :" + type);
            lr.Result = LoginState.LOGIN_OK;
            lr.UID = data["openid"].ToString();
            lr.ChannelLabel = "weixin";
            lr.ChannelUid = data["unionid"].ToString();
            //lr.ProductCode = data["province"].ToString();
            lr.ChannelCode = data["country"].ToString();
            lr.Token = data["openid"].ToString();
            lr.CustomParams = data["privilege"].ToString();
            lr.UserName = data["nickname"].ToString();
            lr.ImageUrl = data["headimgurl"].ToString();
            lr.Sex = data["sex"].ToString();
            Debug.Log("OpenID" + lr.UID);
        }
        else if (state == ResponseState.Fail)
        {
#if UNITY_ANDROID
            Debug.Log("fail! throwable stack = " + result["stack"] + "; error msg = " + result["msg"]);
#elif UNITY_IPHONE
			Debug.Log ("fail! error code = " + result["error_code"] + "; error msg = " + result["error_msg"]);
#endif
            lr.Result = LoginState.LOGIN_FAILED;
        }
        else if (state == ResponseState.Cancel)
        {
            Debug.Log("cancel !");
            lr.Result = LoginState.LOGIN_FAILED;
        }
        SDKMgr.Instance.SDKCallback.LoginCallback(lr);
    }
    void OnShareResultHandler(int reqID, cn.sharesdk.unity3d.ResponseState state, cn.sharesdk.unity3d.PlatformType type, Hashtable result)
    {
        Debug.Log("OnShareResultHandler");
    }
    void OnGetFriendsResultHandler(int reqID, cn.sharesdk.unity3d.ResponseState state, cn.sharesdk.unity3d.PlatformType type, Hashtable result)
    {
        Debug.Log("OnGetFriendsResultHandler");
    }
    void OnFollowFriendResultHandler(int reqID, cn.sharesdk.unity3d.ResponseState state, cn.sharesdk.unity3d.PlatformType type, Hashtable result)
    {
        Debug.Log("OnFollowFriendResultHandler");
    }
}
