using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour {
    public static string panl = string.Empty;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(this.gameObject).onClick = OnEvent;
	}

    void OnEvent(GameObject obj)
    {
        panl = this.transform.GetChild(0).GetComponent<UILabel>().text;
        GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").GetChild(0).GetComponent<UILabel>().text = panl;
        GlobalHallUIMgr.Instance.ShowSystemTipsUI(string.Format("切换到{0},请点击确定按钮进行修改",panl), 2f, false);
    }
   
}
