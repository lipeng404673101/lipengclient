using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class Niuskillbtn : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        UIEventListener.Get(this.gameObject).onClick = Button;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Button(GameObject obj)
    {
        string label = this.transform.GetChild(0).GetComponent<UILabel>().text;
        //bool[] Bools = { true, true, false, false };
        //CL_Cmd_OxAdmin ncb10 = new CL_Cmd_OxAdmin();
        //ncb10.SetCmdType(NetCmdType.CMD_CL_OxAdmin);
        //ncb10.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_SET_WIN_AREA);
        //tagOxAdminReq rep = new tagOxAdminReq();
        //rep.m_cbExcuteTimes = 2;
        //rep.m_cbControlStyle = (byte)(CONTROL_COMMON_INNER.CS_BET_AREA);
        //rep.m_bWinArea = Bools;
        //ncb10.cbExtendData = rep;
        //ncb10.dwUserID = 20499;
        //ncb10.dwUserIDContrl = 20408;
        //NetServices.Instance.Send<CL_Cmd_OxAdmin>(ncb10);
        switch (label)
        {
            case "牛牛":
                Transform jia =obj.transform.parent.parent.parent;
                foreach (Transform Child in jia)
                {
                    if (Child.name == "xianshi")
                    {
                        Child.gameObject.SetActive(true);
                    }
                }
                break;
        }
    }
}
