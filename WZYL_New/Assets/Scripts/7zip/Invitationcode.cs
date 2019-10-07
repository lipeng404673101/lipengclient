using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invitationcode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIEventListener.Get(this.transform.GetChild(0).GetChild(0).gameObject).onClick = m_Tijiao;
        UIEventListener.Get(this.transform.GetChild(0).GetChild(4).gameObject).onClick = m_backbtn;
    }

    private void m_backbtn(GameObject go)
    {
        foreach (Transform TZ in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
        {
            if (TZ.name == "Sprite")
            {
                TZ.gameObject.SetActive(true);//開始按鈕
            }
        }
        foreach (Transform TR in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
        {
            if (TR.name == "BackRoomCall")
            {
                TR.gameObject.SetActive(false);
            }
        }
    }

    private void m_Tijiao(GameObject go)
    {
        if (this.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UILabel>().text =="")
        {
            GlobalHallUIMgr.Instance.ShowSystemTipsUI("邀请码不能为空", 2f, false);
            foreach (Transform TZ in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
            {
                if (TZ.name == "Sprite")
                {
                    TZ.gameObject.SetActive(true);
                }
            }
            foreach (Transform TR in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
            {
                if (TR.name == "BackRoomCall")
                {
                    TR.gameObject.SetActive(false);
                }
            }
            
        }
        else
        {
            CL_Cmd_ClientDailiBond ncb4 = new CL_Cmd_ClientDailiBond();
            ncb4.SetCmdType(NetCmdType.CMD_CL_ClientDailiBond);
            ncb4.dwUserID = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
            ncb4.dwOtherUserID = uint.Parse(this.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UILabel>().text);
            NetServices.Instance.Send<CL_Cmd_ClientDailiBond>(ncb4);
            foreach (Transform TZ in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
            {
                if (TZ.name == "Sprite")
                {
                    TZ.gameObject.SetActive(true);
                }
            }
            foreach (Transform TR in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
            {
                if (TR.name == "BackRoomCall")
                {
                    TR.gameObject.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
