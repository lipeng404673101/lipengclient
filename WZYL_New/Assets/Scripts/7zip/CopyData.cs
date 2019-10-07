using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CopyData : MonoBehaviour
{

    private UILabel Tlabel;
#if UNITY_IPHONE
                /* Interface to native implementation */
                [DllImport ("__Internal")]
                private static extern void _copyTextToClipboard(string text);
#endif
    private void Start()
    {

        Tlabel = this.transform.parent.GetChild(1).GetComponent<UILabel>();
    }

    // Update is called once per frame
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
    public void OnClick()
    {
       
#if UNITY_ANDROID
        string data = this.transform.parent.GetChild(1).GetComponent<UILabel>().text;
        AndroidJavaObject androidObject = new AndroidJavaObject("com.example.buyuwangzhe.buyu.ClipboardTools");
        AndroidJavaObject actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        if (actClass == null) {
            return;
        }
        androidObject.Call("copyTextToClipboard",actClass, data);//复制到剪贴板
        GlobalHallUIMgr.Instance.ShowSystemTipsUI("复制成功", 2f, false);
        //string text = androidObject.Call<string>("getTextFromClipboard");//从剪贴板中获取文本
#endif

#if UNITY_IOS
        string data = this.transform.parent.GetChild(1).GetComponent<UILabel>().text;
         _copyTextToClipboard(data);
        GlobalHallUIMgr.Instance.ShowSystemTipsUI("复制成功", 2f, false);
#endif
    }
}
