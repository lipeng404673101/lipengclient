using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestDanceControl : MonoBehaviour
{
    private bool _Panl = false;
    // Use this for initialization
    void Start()
    {
        Transform _TypeControl = this.transform.Find("xianshi").transform.Find("TypeControl").GetChild(0);
        foreach (Transform _Buttonbtn in _TypeControl)
        {
            UIEventListener.Get(_Buttonbtn.gameObject).onClick = TypeControlBtn;
        }
        Transform _Control = this.transform.Find("xianshi");
        foreach (Transform _Buttonbtn in _Control)
        {
            if (_Buttonbtn.name == "chongzhi" || _Buttonbtn.name == "zhixing" || _Buttonbtn.name == "quxiao")
                UIEventListener.Get(_Buttonbtn.gameObject).onClick = Control;
        }
    }
    // Update is called once per frame
    void TypeControlBtn(GameObject obj)
    {
        switch (obj.name)
        {
            case "Sprite1":
                if (obj.transform.GetComponent<UISprite>().spriteName == "pw_check0")
                {
                    Transform _DataControl = this.transform.Find("xianshi");
                    foreach (Transform _data in _DataControl)
                    {
                        if (_data.name == "data")
                        {
                            _data.gameObject.SetActive(false);
                        }
                    }
                    foreach (Transform _Child in this.transform.Find("xianshi").transform)
                    {
                        if (_Child.name == "PanlwinControl")
                        {
                            _Child.gameObject.SetActive(true);
                        }
                        if (_Child.name == "cishu")
                        {
                            _Child.gameObject.SetActive(true);
                        }
                    }
                    Transform _PanlwinControl = this.transform.Find("xianshi").transform.Find("PanlwinControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _PanlwinControl)
                    {
                        UIEventListener.Get(_Buttonbtn.gameObject).onClick = PanlwinControlBtn;
                    }
                }
                break;
            case "Sprite2":
                foreach (Transform _Child in this.transform.Find("xianshi").transform)
                {
                    if (_Child.name == "PanlwinControl")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                    if (_Child.name == "RegionControl")
                    {
                        _Child.gameObject.SetActive(false);
                        Transform _TypeControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                        foreach (Transform _Buttonbtn in _TypeControl)
                        {
                            _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                        }
                    }
                    if (_Child.name == "cishu")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                }
                break;
            case "Sprite3":
                foreach (Transform _Child in this.transform.Find("xianshi").transform)
                {
                    if (_Child.name == "PanlwinControl")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                    if (_Child.name == "RegionControl")
                    {
                        _Child.gameObject.SetActive(false);
                        Transform _TypeControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                        foreach (Transform _Buttonbtn in _TypeControl)
                        {
                            _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                        }
                    }
                    if (_Child.name == "cishu")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                }
                break;
            case "Sprite4":
                foreach (Transform _Child in this.transform.Find("xianshi").transform)
                {
                    if (_Child.name == "PanlwinControl")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                    if (_Child.name == "RegionControl")
                    {
                        _Child.gameObject.SetActive(false);
                        Transform _TypeControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                        foreach (Transform _Buttonbtn in _TypeControl)
                        {
                            _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                        }
                    }
                    if (_Child.name == "cishu")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                }
                break;
            case "Sprite5":
                foreach (Transform _Child in this.transform.Find("xianshi").transform)
                {
                    if (_Child.name == "PanlwinControl")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                    if (_Child.name == "RegionControl")
                    {
                        _Child.gameObject.SetActive(false);
                        Transform _TypeControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                        foreach (Transform _Buttonbtn in _TypeControl)
                        {
                            _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                        }
                    }
                    if (_Child.name == "cishu")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                }
                break;
            case "Sprite6":
                foreach (Transform _Child in this.transform.Find("xianshi").transform)
                {
                    if (_Child.name == "PanlwinControl")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                    if (_Child.name == "RegionControl")
                    {
                        _Child.gameObject.SetActive(false);
                        Transform _TypeControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                        foreach (Transform _Buttonbtn in _TypeControl)
                        {
                            _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                        }
                    }
                    if (_Child.name == "cishu")
                    {
                        _Child.gameObject.SetActive(false);
                    }
                }
                break;
        }
        switch (obj.transform.GetComponent<UISprite>().spriteName)
        {
            case "pw_check0":
                Transform _TypeControlWR = this.transform.Find("xianshi").transform.Find("TypeControl").GetChild(0);
                foreach (Transform _Buttonbtn in _TypeControlWR)
                {
                    _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                    _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                }
                obj.transform.GetComponent<UISprite>().spriteName = "pw_check1";
                obj.transform.GetComponent<UIButton>().normalSprite = "pw_check1";
                break;
            case "pw_check1":
                obj.transform.GetComponent<UISprite>().spriteName = "pw_check0";
                obj.transform.GetComponent<UIButton>().normalSprite = "pw_check0";
                if (obj.name == "Sprite1")
                {
                    Transform _PanlwinControl = this.transform.Find("xianshi").transform.Find("PanlwinControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _PanlwinControl)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                    this.transform.Find("xianshi").transform.Find("PanlwinControl").gameObject.SetActive(false);
                    Transform _RegionControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _RegionControl)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                    this.transform.Find("xianshi").transform.Find("RegionControl").gameObject.SetActive(false);
                }
                break;
        }

    }
    void PanlwinControlBtn(GameObject obj)
    {
        switch (obj.transform.GetComponent<UISprite>().spriteName)
        {
            case "pw_check0":
                Transform _RegionControlTy = this.transform.Find("xianshi").transform.Find("PanlwinControl").GetChild(0);
                foreach (Transform _Buttonbtn in _RegionControlTy)
                {
                    _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                    _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                }
                obj.transform.GetComponent<UISprite>().spriteName = "pw_check1";
                obj.transform.GetComponent<UIButton>().normalSprite = "pw_check1";
                break;
            case "pw_check1":
                obj.transform.GetComponent<UISprite>().spriteName = "pw_check0";
                obj.transform.GetComponent<UIButton>().normalSprite = "pw_check0";
                break;
        }
        if (obj.name == "Sprite3")
        {
            foreach (Transform _Child in this.transform.Find("xianshi").transform)
            {
                if (_Child.name == "RegionControl")
                {
                    _Child.gameObject.SetActive(true);
                    Transform _TypeControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControl)
                    {
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                    }
                }
            }
            Transform _RegionControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
            foreach (Transform _Buttonbtn in _RegionControl)
            {
                UIEventListener.Get(_Buttonbtn.gameObject).onClick = RegionControlBtn;
            }
        }
        else
        {
            foreach (Transform _Child in this.transform.Find("xianshi").transform)
            {

                if (_Child.name == "RegionControl")
                {
                    _Child.gameObject.SetActive(false);
                }
            }
        }
        //if (obj.name == "Sprite3" && obj.transform.GetComponent<UISprite>().spriteName == "pw_check1")
        //{
        //    foreach (Transform _Child in this.transform.Find("xianshi").transform)
        //    {
        //        if (_Child.name == "RegionControl")
        //        {
        //            _Child.gameObject.SetActive(false);
        //            Transform _TypeControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
        //            foreach (Transform _Buttonbtn in _TypeControl)
        //            {
        //                _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
        //            }
        //        }
        //    }
        //}
    }
    void RegionControlBtn(GameObject obj)
    {
        switch (obj.transform.GetComponent<UISprite>().spriteName)
        {
            case "pw_check0":
                Transform _RegionControl = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                foreach (Transform Region in _RegionControl)
                {
                    Region.GetComponent<UISprite>().spriteName = "pw_check0";
                    Region.GetComponent<UIButton>().normalSprite = "pw_check0";
                }
                obj.transform.GetComponent<UISprite>().spriteName = "pw_check1";
                obj.transform.GetComponent<UIButton>().normalSprite = "pw_check1";
                break;
            case "pw_check1":
                obj.transform.GetComponent<UISprite>().spriteName = "pw_check0";
                obj.transform.GetComponent<UIButton>().normalSprite = "pw_check0";
                break;
        }
    }
    void Control(GameObject obj)
    {
        switch (obj.name)
        {
            case "chongzhi":
                if (this.transform.Find("xianshi").transform.Find("TypeControl") != null)
                {
                    Transform _TypeControlBack = this.transform.Find("xianshi").transform.Find("TypeControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControlBack)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                }
                if (this.transform.Find("xianshi").transform.Find("PanlwinControl") != null)
                {
                    Transform _TypeControlBack = this.transform.Find("xianshi").transform.Find("PanlwinControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControlBack)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                    this.transform.Find("xianshi").transform.Find("PanlwinControl").gameObject.SetActive(false);
                }
                if (this.transform.Find("xianshi").transform.Find("RegionControl") != null)
                {
                    Transform _TypeControlBack = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControlBack)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                    this.transform.Find("xianshi").transform.Find("RegionControl").gameObject.SetActive(false);
                }
                Transform _DataControl = this.transform.Find("xianshi");
                foreach (Transform _data in _DataControl)
                {
                    if (_data.name == "data")
                    {
                        _data.gameObject.SetActive(false);
                    }
                }
                break;
            case "zhixing":
                Transform QWE = this.transform.Find("xianshi").transform.Find("TypeControl").GetChild(0);
                int h = 0;
                foreach (Transform th in QWE)
                {
                    if (th.GetComponent<UISprite>().spriteName == "pw_check0")
                    {
                        h++;
                    }
                }
                if (h == 6)
                {
                    GlobalHallUIMgr.Instance.ShowSystemTipsUI("信息不足", 2f, false);
                    break;
                }
                if (this.transform.Find("xianshi").transform.Find("TypeControl") != null)
                {
                    Transform _TypeControlBack = this.transform.Find("xianshi").transform.Find("TypeControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControlBack)
                    {
                        if (_Buttonbtn.GetComponent<UISprite>().spriteName == "pw_check1")
                        {
                            switch (_Buttonbtn.name)
                            {
                                case "Sprite1":
                                    Transform PanlChild = this.transform.Find("xianshi").transform.Find("PanlwinControl").GetChild(0);
                                    int j = 0;
                                    foreach (Transform th in PanlChild)
                                    {
                                        if (th.GetComponent<UISprite>().spriteName == "pw_check0")
                                        {
                                            j++;
                                        }
                                    }
                                    if (j == 3)
                                    {
                                        
                                        GlobalHallUIMgr.Instance.ShowSystemTipsUI("信息不足", 2f, false);
                                        break;
                                    }
                                    if (this.transform.Find("xianshi").transform.Find("cishu").transform.GetChild(1).GetComponent<UILabel>().text == "")
                                    {
                                        GlobalHallUIMgr.Instance.ShowSystemTipsUI("信息不足", 2f, false);
                                        break;
                                    }
                                    // string ID = this.transform.Find("xianshi").transform.Find("dwuserIDControl").GetChild(1).GetComponent<UILabel>().text;
                                    string Count = this.transform.Find("xianshi").transform.Find("cishu").GetChild(1).GetComponent<UILabel>().text;
                                    CL_Cmd_AnimalAdmin ncb = new CL_Cmd_AnimalAdmin();
                                    ncb.SetCmdType(NetCmdType.CMD_CL_AnimalAdmin);
                                    ncb.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_SET_WIN_AREA);
                                    tagAnimalAdminReq rep = new tagAnimalAdminReq();
                                    rep.m_cbExcuteTimes = byte.Parse(Count);
                                    if (this.transform.Find("xianshi").transform.Find("PanlwinControl") != null)
                                    {
                                        Transform _PanlwinControlBack = this.transform.Find("xianshi").transform.Find("PanlwinControl").GetChild(0);
                                        foreach (Transform Buttonbtn in _PanlwinControlBack)
                                        {
                                            if (Buttonbtn.GetComponent<UISprite>().spriteName == "pw_check1")
                                            {
                                                if (Buttonbtn.name == "Sprite1")
                                                    rep.m_cbControlStyle = (byte)(CONTROL_COMMON_INNER.CS_BANKER_LOSE);
                                                if (Buttonbtn.name == "Sprite2")
                                                    rep.m_cbControlStyle = (byte)(CONTROL_COMMON_INNER.CS_BANKER_WIN);
                                                if (Buttonbtn.name == "Sprite3")
                                                    rep.m_cbControlStyle = (byte)(CONTROL_COMMON_INNER.CS_BET_AREA);
                                            }
                                        }
                                        int zhabi =0;
                                        Transform PanlwinControlBack = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                                        foreach (Transform Buttonbtn in PanlwinControlBack)
                                        {
                                           
                                            if (Buttonbtn.GetComponent<UISprite>().spriteName == "pw_check1")
                                            {    
                                                
                                                 Debug.Log("控制区域");
                                                rep.m_cbarea =(byte)(zhabi-1);
                                                Debug.Log(rep.m_cbarea);
                                            }
                                            zhabi++; 
                                        }
                                       
                                    }
                                    ncb.cbExtendData = rep;
                                    ncb.dwUserIDContrl = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                                    NetServices.Instance.Send<CL_Cmd_AnimalAdmin>(ncb);
                                    break;
                                case "Sprite2":
                                    Transform _DataControl12 = this.transform.Find("xianshi");
                                    foreach (Transform _data in _DataControl12)
                                    {
                                        if (_data.name == "data")
                                        {
                                            _data.gameObject.SetActive(true);
                                        }
                                    }
                                    CL_Cmd_AnimalAdmin ncb1 = new CL_Cmd_AnimalAdmin();
                                    ncb1.SetCmdType(NetCmdType.CMD_CL_AnimalAdmin);
                                    ncb1.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_RESET_CONTROL);
                                    tagAnimalAdminReq rep2 = new tagAnimalAdminReq();
                                    ncb1.cbExtendData = rep2;
                                    ncb1.dwUserIDContrl = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                                    NetServices.Instance.Send<CL_Cmd_AnimalAdmin>(ncb1);
                                    break;
                                case "Sprite3":
                                    Transform _DataControl1 = this.transform.Find("xianshi");
                                    foreach (Transform _data in _DataControl1)
                                    {
                                        if (_data.name == "data")
                                        {
                                            _data.gameObject.SetActive(true);
                                        }
                                    }
                                    CL_Cmd_AnimalAdmin ncb2 = new CL_Cmd_AnimalAdmin();
                                    ncb2.SetCmdType(NetCmdType.CMD_CL_AnimalAdmin);
                                    ncb2.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_PRINT_SYN);
                                    tagAnimalAdminReq rep3 = new tagAnimalAdminReq();
                                    ncb2.cbExtendData = rep3;
                                    ncb2.dwUserIDContrl = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                                    NetServices.Instance.Send<CL_Cmd_AnimalAdmin>(ncb2);
                                    break;
                                case "Sprite4":
                                    Transform _DataControl2 = this.transform.Find("xianshi");
                                    foreach (Transform _data in _DataControl2)
                                    {
                                        if (_data.name == "data")
                                        {
                                            _data.gameObject.SetActive(true);
                                        }
                                    }
                                    CL_Cmd_AnimalAdmin ncb3 = new CL_Cmd_AnimalAdmin();
                                    ncb3.SetCmdType(NetCmdType.CMD_CL_AnimalAdmin);
                                    ncb3.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_QUERY_NAMES);
                                    tagAnimalAdminReq rep1 = new tagAnimalAdminReq();
                                    ncb3.cbExtendData = rep1;
                                    ncb3.dwUserIDContrl = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                                    NetServices.Instance.Send<CL_Cmd_AnimalAdmin>(ncb3);
                                    break;
                                case "Sprite5":
                                    Transform _DataControl3 = this.transform.Find("xianshi");
                                    foreach (Transform _data in _DataControl3)
                                    {
                                        if (_data.name == "data")
                                        {
                                            _data.gameObject.SetActive(true);
                                        }
                                    }
                                    string ID1 = this.transform.Find("xianshi").transform.Find("dwuserIDControl").GetChild(1).GetComponent<UILabel>().text;
                                    CL_Cmd_AnimalAdmin ncb4 = new CL_Cmd_AnimalAdmin();
                                    ncb4.SetCmdType(NetCmdType.CMD_CL_AnimalAdmin);
                                    ncb4.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_QUERY_PLAYERJETTON);
                                    tagAnimalAdminReq rep4 = new tagAnimalAdminReq();
                                    ncb4.cbExtendData = rep4;
                                    ncb4.dwUserIDContrl = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                                    NetServices.Instance.Send<CL_Cmd_AnimalAdmin>(ncb4);
                                    break;
                                case "Sprite6":
                                    Transform _DataControl4 = this.transform.Find("xianshi");
                                    foreach (Transform _data in _DataControl4)
                                    {
                                        if (_data.name == "data")
                                        {
                                            _data.gameObject.SetActive(true);
                                        }
                                    }
                                    CL_Cmd_AnimalAdmin ncb5 = new CL_Cmd_AnimalAdmin();
                                    ncb5.SetCmdType(NetCmdType.CMD_CL_AnimalAdmin);
                                    ncb5.cbReqType = (byte)(CONTROL_COMMON_INNER.RQ_QUERY_ALLJETTON);
                                    tagAnimalAdminReq rep5 = new tagAnimalAdminReq();
                                    ncb5.cbExtendData = rep5;
                                    ncb5.dwUserIDContrl = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                                    NetServices.Instance.Send<CL_Cmd_AnimalAdmin>(ncb5);
                                    break;
                            }
                        }
                    }
                }
                break;
            case "quxiao":
                if (this.transform.Find("xianshi").transform.Find("TypeControl") != null)
                {
                    Transform _TypeControlBack = this.transform.Find("xianshi").transform.Find("TypeControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControlBack)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                }
                if (this.transform.Find("xianshi").transform.Find("PanlwinControl") != null)
                {
                    Transform _TypeControlBack = this.transform.Find("xianshi").transform.Find("PanlwinControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControlBack)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                    this.transform.Find("xianshi").transform.Find("PanlwinControl").gameObject.SetActive(false);
                }
                if (this.transform.Find("xianshi").transform.Find("RegionControl") != null)
                {
                    Transform _TypeControlBack = this.transform.Find("xianshi").transform.Find("RegionControl").GetChild(0);
                    foreach (Transform _Buttonbtn in _TypeControlBack)
                    {
                        _Buttonbtn.GetComponent<UISprite>().spriteName = "pw_check0";
                        _Buttonbtn.GetComponent<UIButton>().normalSprite = "pw_check0";
                    }
                    this.transform.Find("xianshi").transform.Find("RegionControl").gameObject.SetActive(false);
                }
                this.transform.GetChild(0).gameObject.SetActive(false);
                break;
        }
    }

}
