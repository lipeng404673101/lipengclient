using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobelSet : MonoBehaviour {
    // Use this for initialization
    public bool Panl = false;
	void Start () {
        UIEventListener.Get(this.transform.GetChild(6).gameObject).onClick = OnOKbtn;
        UIEventListener.Get(this.transform.GetChild(2).gameObject).onClick = OnBackbtn;
        //UIEventListener.Get()
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnOKbtn(GameObject obj)
    {
        Panl = true;
        int userID = int.Parse(this.transform.GetChild(4).GetChild(1).GetComponent<UILabel>().text);
        double GlobalNum = double.Parse(this.transform.GetChild(5).GetChild(1).GetComponent<UILabel>().text);
        double panl= (double)PlayerRole.Instance.RoleInfo.RoleMe.GetGlobel()/1000;
        //if (GlobalNum % 10 != 0)
        //{
        //    Panl = false;
        //    GlobalHallUIMgr.Instance.ShowSystemTipsUI("玩家金币充值必须为大于10的整数",2f,false);
        //}
        if (GlobalNum > panl||GlobalNum<0)
        {
            Panl = false;
            GlobalHallUIMgr.Instance.ShowSystemTipsUI("充值金额错误", 2f, false);
            return;
            //GlobalNum =(double)panl;
            //this.transform.GetChild(5).GetChild(1).GetComponent<UILabel>().text = panl.ToString();
        }
        if (Panl)
        {
            CL_Cmd_ChangeUserGold ncb1 = new CL_Cmd_ChangeUserGold();
            ncb1.SetCmdType(NetCmdType.CMD_CL_ChangeUserGold);
            ncb1.UserIDself = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
            ncb1.UserID = (uint)userID;
            ncb1.GlobalNum = (uint)(GlobalNum * 1000);
            ncb1.bIsZongDai = skillplane.UserAgent;
            NetServices.Instance.Send<CL_Cmd_ChangeUserGold>(ncb1);
        }
    }
    void OnBackbtn(GameObject obj)
    {
        GameObject.Destroy(this.gameObject);
        GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("HallWindBtns(Clone)").GetChild(0).GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(true);
        GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)").GetChild(8).gameObject.SetActive(false);
    }
}
