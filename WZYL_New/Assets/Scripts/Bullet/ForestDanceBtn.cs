using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDanceBtn : MonoBehaviour {
    public GameObject obj;

	// Use this for initialization
	void Start () {
        obj.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickBtn()
    {

        obj.SetActive(true);
        //CL_Cmd_AnimalAdmin ncb10 = new CL_Cmd_AnimalAdmin();
        //ncb10.SetCmdType(NetCmdType.CMD_CL_AnimalAdmin);
        //ncb10.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_SET_WIN_AREA);
        //tagAnimalAdminReq rep = new tagAnimalAdminReq();
        //rep.m_cbExcuteTimes = 2;
        //rep.m_cbControlStyle = (byte)(CONTROL_COMMON_INNER.CS_BET_AREA);
        //rep.m_cbarea = 1;
        //ncb10.cbExtendData = rep;
        //ncb10.dwUserID = 20775;
        //ncb10.dwUserIDContrl = 20366;
        //NetServices.Instance.Send<CL_Cmd_AnimalAdmin>(ncb10);
    }
}
