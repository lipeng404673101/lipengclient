using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Test : MonoBehaviour {
    StringBuilder logString = new StringBuilder();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButton()
    {
        logString.Append("DDDDDDDDDDDDDDDDDDD /n");
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("SdkLogin");
    }
}
