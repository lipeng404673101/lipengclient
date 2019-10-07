using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterControl : MonoBehaviour
{
    // Use this for initialization
    public string _Skill = string.Empty;
    public static bool UserAgent = false;

    public bool IsScoreDown = false;

    public GameObject ScoreDown;
    //public GameObject ScoreAdd;



    public static string num = "";
    void Start()
    {
        ScoreDown = GameObject.Find("Scroll").transform.Find("Top").GetChild(3).GetChild(0).gameObject;
        //ScoreAdd = GameObject.Find("Scroll").transform.Find("Top").GetChild(3).GetChild(1).gameObject;


        foreach (Transform _TR in GameObject.Find("Scroll").transform.Find("List").transform)
        {
            UIEventListener.Get(_TR.gameObject).onClick = _Skillbtn;
        }
        foreach (Transform _TR in GameObject.Find("Scroll").transform.Find("Under").transform)
        {
            UIEventListener.Get(_TR.gameObject).onClick = _ControlBtn;
        }

        UIEventListener.Get(ScoreDown).onClick = ScoreDownBtn;

    }

    private void ScoreDownBtn(GameObject go)
    {

        if (GameObject.Find("Scroll").transform.Find("Top").GetChild(3).GetChild(0).GetChild(0).gameObject.activeSelf == false)//更新
        {
            GameObject.Find("Scroll").transform.Find("Top").GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);
            IsScoreDown = true;
            Debug.Log("ScoreAddBtn " + ScoreDown + IsScoreDown);
        }
        else
        {
            GameObject.Find("Scroll").transform.Find("Top").GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
            IsScoreDown = false;
            Debug.Log("ScoreAddBtn " + ScoreDown + IsScoreDown);
        }
    }

    private void _Skillbtn(GameObject go)
    {

        foreach (Transform _TR in GameObject.Find("Scroll").transform.Find("List").transform)
        {
            //foreach (Transform _TD in _TR)
            //{
            //    if (_TD.name == "ti")
            //    {
            //        Debug.Log("1");
            //        _TD.gameObject.SetActive(false);
            //    }
            //}
            if (_TR.Find("ti") != null)
            {
                _TR.Find("ti").gameObject.SetActive(false);
            }
        }
        foreach (Transform _TD in go.transform)
        {
            if (_TD.name == "Label")
            {
                Debug.Log("3");
                _ChoosePanle();
                switch (_TD.GetComponent<UILabel>().text)
                {
                    case "修改金币":
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }
                        }
                        _ChooseUI(true, false, false, true, false, false, false, StringTable.GetString("one"));
                        List<string> list = new List<string>();
                        list.Add("Gold");
                        list.Add("UserID");
                        _ChooseSkill(list);
                        _Skillstr("one");
                        break;
                    case "踢出玩家":
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }
                        }
                        _ChooseUI(true, false, false, false, false, false, false, StringTable.GetString("two"));
                        List<string> listone = new List<string>();
                        listone.Add("UserID");
                        listone.Add("GameID");
                        listone.Add("ColdTime");
                        _ChooseSkill(listone);
                        _Skillstr("two");
                        break;
                    case "修改名字":
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }
                        }
                        _ChooseUI(true, false, false, false, false, false, false, StringTable.GetString("three"));
                        List<string> listtwo = new List<string>();
                        listtwo.Add("UserID");
                        listtwo.Add("UserName");
                        _ChooseSkill(listtwo);
                        _Skillstr("three");
                        break;
                    case "发送公告":
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }
                        }
                        _ChooseUI(false, false, true, false, false, false, false, StringTable.GetString("four"));
                        _Skillstr("four");
                        break;
                    case "查询库存":
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }
                        }
                        _ChooseUI(false, false, false, false, false, true, false, StringTable.GetString("five"));
                        //List<string> listfour = new List<string>();
                        //listfour.Add("UserID");
                        //_ChooseSkill(listfour);
                        _Skillstr("five");
                        break;
                    case "修改库存"://"在线玩家"
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }
                        }
                        _ChooseUI(false, false, false, false, false, false, true, StringTable.GetString("six"));
                        List<string> listfive = new List<string>();
                        listfive.Add("UserID");
                        listfive.Add("GameID");
                        _ChooseSkill2(listfive);
                        _Skillstr("six");
                        break;
                    case "更新配置表":
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }
                        }
                        _ChooseUI(false, false, false, false, true, false, false, StringTable.GetString("seven"));
                        List<string> listsix = new List<string>();
                        _ChooseSkill(listsix);
                        _Skillstr("seven");
                        break;
                    case "修改概率":
                        foreach (Transform a in _TD.parent)
                        {
                            if (a.name == "ti")
                            {
                                Debug.Log("2");
                                a.gameObject.SetActive(true);
                            }

                        }
                        _ChooseUI(false, true, false, false, false, false, false, StringTable.GetString("eight"));
                        foreach (Transform TR in this.transform.Find("Scroll").transform.Find("Top").transform.Find("Global").transform.Find("listGlobal"))
                        {
                            UIEventListener.Get(TR.gameObject).onClick = OnProbability;
                        }
                        _Skillstr("eight");
                        break;

                }
            }
        }
    }

    private void OnProbability(GameObject go)
    {
        foreach (Transform TR in this.transform.Find("Scroll").transform.Find("Top").transform.Find("Global").transform.Find("listGlobal"))
        {
            if (TR.Find("Black") != null)
            {
                TR.Find("Black").gameObject.SetActive(false);
            }
        }
        foreach (Transform Black in go.transform)
        {
            if (Black.name == "Black")
            {
                Black.gameObject.SetActive(true);
            }
        }
    }

    void _ChooseUI(bool ListSprite, bool Global, bool Notice, bool MessageTalk, bool Refresh, bool Inquiry, bool modify, string tabel)
    {
        this.transform.Find("Scroll").transform.Find("undertop").transform.Find("Label").GetComponent<UILabel>().text = tabel;

        foreach (Transform TR in this.transform.Find("Scroll").transform.Find("Top"))
        {
            if (TR.name == "listSprite")
            {
                TR.gameObject.SetActive(ListSprite);
            }
            if (TR.name == "Global")
            {
                TR.gameObject.SetActive(Global);
            }
            if (TR.name == "Notice")
            {
                TR.gameObject.SetActive(Notice);
            }
            if (TR.name == "MessageTalk")
            {
                TR.gameObject.SetActive(MessageTalk);
            }
            if (TR.name == "ConfigRefresh")
            {
                TR.gameObject.SetActive(Refresh);
            }
            if (TR.name == "InquirySprite")
            {
                TR.gameObject.SetActive(Inquiry);
            }
            if (TR.name == "modifySprite")
            {
                TR.gameObject.SetActive(modify);
            }

        }
    }
    void _ChoosePanle()
    {
        foreach (Transform RE in GameObject.Find("Scroll").transform.Find("Top").transform.Find("listSprite"))
        {
            foreach (Transform R in RE.Find("Write"))
            {
                R.gameObject.SetActive(false);
            }
        }
    }
    void _ChooseSkill2(List<string> list)
    {
        foreach (Transform RE in GameObject.Find("Scroll").transform.Find("Top").transform.Find("modifySprite"))
        {
            RE.GetChild(0).GetChild(0).GetComponent<UILabel>().text = "禁止添加";
            RE.GetChild(0).GetChild(0).GetComponent<UILabel>().color = Color.red;
            RE.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (RE.name == list[i])
                {
                    RE.GetChild(0).GetChild(0).GetComponent<UILabel>().text = "未输入";
                    RE.GetChild(0).GetChild(0).GetComponent<UILabel>().color = Color.black;
                    RE.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
                    foreach (Transform R in RE.Find("Write"))
                    {
                        R.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    void _ChooseSkill(List<string> list)
    {
        foreach (Transform RE in GameObject.Find("Scroll").transform.Find("Top").transform.Find("listSprite"))
        {
            RE.GetChild(0).GetChild(0).GetComponent<UILabel>().text = "禁止添加";
            RE.GetChild(0).GetChild(0).GetComponent<UILabel>().color = Color.red;
            RE.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (RE.name == list[i])
                {
                    RE.GetChild(0).GetChild(0).GetComponent<UILabel>().text = "未输入";
                    RE.GetChild(0).GetChild(0).GetComponent<UILabel>().color = Color.black;
                    RE.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
                    foreach (Transform R in RE.Find("Write"))
                    {
                        R.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    public void _Skillstr(string str)
    {
        _Skill = str;
    }
    private void _ControlBtn(GameObject obj)
    {
        switch (obj.name)
        {
            case "Determine":
                switch (_Skill)
                {
                    case "one":
                        string User = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        string gold = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(4).GetChild(0).GetChild(0).GetComponent<UILabel>().text;

                        if (User == "未输入" && gold == "未输入")
                        {
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("选中项信息不完整", 2f, false);
                        }
                        //else if (double.Parse(gold) < 0)
                        //{
                        //    GlobalHallUIMgr.Instance.ShowSystemTipsUI("金币充值过低", 2f, false);
                        //}
                        else
                        {
                            Debug.Log("修改金币");
                            int userID = int.Parse(User);
                            double GlobalNum = double.Parse(gold);
                            if (GlobalNum < 0)
                            {
                                GlobalHallUIMgr.Instance.ShowSystemTipsUI("金币充值过低", 2f, false);
                            }
                            else
                            {
                                CL_Cmd_ChangeUserGold ncb1 = new CL_Cmd_ChangeUserGold();
                                ncb1.SetCmdType(NetCmdType.CMD_CL_ChangeUserGold);
                                ncb1.UserIDself = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                                ncb1.UserID = (uint)userID;
                                ncb1.GlobalNum = (uint)(GlobalNum * 1000);
                                ncb1.bIsZongDai = UserAgent;
                                ncb1.bIsScoreDown = IsScoreDown;
                                NetServices.Instance.Send<CL_Cmd_ChangeUserGold>(ncb1);
                                //GlobalHallUIMgr.Instance.ShowSystemTipsUI("发送成功", 2f, false);
                            }
                        }
                        break;
                    case "two":
                        string User1 = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        string Game = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        string Time = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        if (User1 == "未输入" && Game == "未输入" && Time == "未输入")
                        {
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("选中项信息不完整", 2f, false);
                        }
                        else
                        {
                            Debug.Log("踢出玩家");
                            int UserID = int.Parse(User1);
                            int ClientID = int.Parse(Game);
                            int FreeClod = int.Parse(Time);
                            CL_Cmd_KickUserByID ncb = new CL_Cmd_KickUserByID();
                            ncb.SetCmdType(NetCmdType.CMD_CL_KickUserByID);
                            ncb.UserID = (uint)UserID;
                            ncb.ClientID = (uint)ClientID;
                            ncb.FreezeMin = (uint)FreeClod;
                            NetServices.Instance.Send<CL_Cmd_KickUserByID>(ncb);
                        }
                        break;
                    case "three":
                        string User2 = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        string Name = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        if (User2 == "未输入" && Name == "未输入")
                        {
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("选中项信息不完整", 2f, false);
                        }
                        else
                        {
                            Debug.Log("修改姓名");
                            int SelfID = (int)PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                            int UserIID = int.Parse(User2);
                            string SelfName = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("HeadWind(Clone)").GetChild(0).GetChild(8).GetChild(0).GetComponent<UILabel>().text;
                            if (Name == SelfName && SelfID == UserIID)
                            {
                                GlobalHallUIMgr.Instance.ShowSystemTipsUI("与自身名字相同", 2f, false);
                            }
                            else
                            {
                                CL_Cmd_ChangeaNickName ncb2 = new CL_Cmd_ChangeaNickName();
                                ncb2.SetCmdType(NetCmdType.CMD_CL_ChangeaNickName);
                                ncb2.RankValue = (uint)UserIID;
                                ncb2.MachineCode = Name;
                                NetServices.Instance.Send<CL_Cmd_ChangeaNickName>(ncb2);
                            }
                        }
                        break;
                    case "four":
                        string gonggao = this.transform.Find("Scroll").transform.Find("Top").GetChild(2).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        if (gonggao == "")
                        {
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("选中项信息不完整", 2f, false);
                        }
                        else
                        {
                            Debug.Log(gonggao);
                            // string CenterMessage = obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                            CL_Cmd_SendMsgToAllGame ncb4 = new CL_Cmd_SendMsgToAllGame();
                            ncb4.SetCmdType(NetCmdType.CMD_CL_SendMsgToAllGame);
                            ncb4.Param = 12;
                            ncb4.MessageColor = 4294967295;
                            ncb4.StepNum = 3;
                            ncb4.StepSec = 30;
                            ncb4.MessageSize = UInt16.Parse(gonggao.Length.ToString());
                            Debug.Log("发送消息：" + gonggao.ToString());
                            ncb4.CenterMessage = gonggao.ToString();
                            NetServices.Instance.Send<CL_Cmd_SendMsgToAllGame>(ncb4);
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("发送成功", 2f, false);
                        }
                        break;
                    case "five":
                        //string User3 = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;

                        //if (User3 == "未输入")
                        //{
                        //    GlobalHallUIMgr.Instance.ShowSystemTipsUI("选中项信息不完整", 2f, false);
                        //}
                        //else
                        //{
                        Debug.Log("查询库存");
                        CL_Cmd_QueryFishPool ncb5 = new CL_Cmd_QueryFishPool();
                        ncb5.SetCmdType(NetCmdType.CMD_CL_QueryFishPool);
                        ncb5.UserID = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                        NetServices.Instance.Send<CL_Cmd_QueryFishPool>(ncb5);
                        GlobalHallUIMgr.Instance.ShowSystemTipsUI("发送成功", 2f, false);

                        //}
                        break;
                    case "six":
                        //string User4 = this.transform.Find("Scroll").transform.Find("Top").GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;

                        string tableId = this.transform.Find("Scroll").transform.Find("Top").GetChild(6).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                        string value = this.transform.Find("Scroll").transform.Find("Top").GetChild(6).GetChild(1).GetChild(0).GetChild(0).GetComponent<UILabel>().text;

                        if (value == "未输入" || tableId == "未输入")
                        {
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("选中项信息不完整", 2f, false);
                        }
                        if(byte.Parse(tableId)<0|| byte.Parse(tableId) > 3)
                        {
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("请输入正确的房间ID", 2f, false);
                        }
                        else
                        {
                            Debug.Log("修改库存");

                            CL_Cmd_HandleTablePoolGailv ncb51 = new CL_Cmd_HandleTablePoolGailv();
                            ncb51.SetCmdType(NetCmdType.Cmd_CL_HandleTablePoolGailv);
                            ncb51.nValue = double.Parse(value) * 1000;
                            Debug.Log("value==" + value);
                            Debug.Log("value==" + ncb51.nValue);
                            ncb51.TableID = byte.Parse(tableId);
                            NetServices.Instance.Send<CL_Cmd_HandleTablePoolGailv>(ncb51);
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("发送成功", 2f, false);
                            //Debug.Log("在线玩家");
                            //int dwUserID = int.Parse(User4);
                            //// int clientID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text);
                            //CL_Cmd_QueryOnlineUserInfo ncb6 = new CL_Cmd_QueryOnlineUserInfo();
                            //ncb6.SetCmdType(NetCmdType.CMD_CL_QueryOnlineUserInfo);
                            //ncb6.UserId = (uint)dwUserID;
                            //ncb6.NULL = (uint)dwUserID;
                            //NetServices.Instance.Send<CL_Cmd_QueryOnlineUserInfo>(ncb6);
                        }
                        break;
                    case "seven":
                        Debug.Log("更新配置表");
                        CL_Cmd_ReloadConfig ncb7 = new CL_Cmd_ReloadConfig();
                        ncb7.SetCmdType(NetCmdType.CMD_CL_ReloadConfig);
                        NetServices.Instance.Send<CL_Cmd_ReloadConfig>(ncb7);
                        GlobalHallUIMgr.Instance.ShowSystemTipsUI("更新成功", 2f, false);
                        break;
                    case "eight":
                        int count = 0;
                        foreach (Transform YU in this.transform.Find("Scroll").transform.Find("Top").GetChild(1).GetChild(0))
                        {
                            if (YU.Find("Black").gameObject.activeSelf == false)
                            {
                                count++;
                            }
                        }
                        if (count == 10)
                        {
                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("未选中修改的概率", 2f, false);
                            count = 0;
                        }
                        else
                        {
                            foreach (Transform Y in this.transform.Find("Scroll").transform.Find("Top").GetChild(1).GetChild(0))
                            {

                                if (Y.Find("Black").gameObject.activeSelf)//更新
                                {
                                    Debug.Log("嘿嘿嘿");
                                    CL_Cmd_HandleGailv ncb10 = new CL_Cmd_HandleGailv();
                                    //CL_Cmd_HandleGailv ncb11 = new CL_Cmd_HandleGailv();
                                    ncb10.SetCmdType(NetCmdType.CMD_CL_HandleGailv);
                                    //ncb11.SetCmdType(NetCmdType.CMD_CL_HandleGailv);
                                    if (Y.Find("Sprite").GetChild(0).GetComponent<UILabel>().text == "请输入")
                                    {
                                        num = Y.Find("Sprite").GetChild(0).GetComponent<UIInput>().value;
                                        num = "0";
                                    }
                                    //num = Y.Find("Sprite").GetChild(0).GetComponent<UIInput>().value;
                                    else
                                    {
                                        if (Y.Find("Sprite").GetChild(0).GetComponent<UILabel>().text == num)
                                        {
                                            ncb10.RNumrateF = float.Parse(num);
                                        }
                                        if (ncb10.RNumrateF < 0f || ncb10.RNumrateF > 100f)
                                        {
                                            GlobalHallUIMgr.Instance.ShowSystemTipsUI("输入信息不符", 2f, false);
                                        }

                                    }
                                    if (Y.Find("Sprite").GetChild(0).GetComponent<UILabel>().text == "必输局")
                                    {
                                        ncb10.RNumrateF = 0.3f;
                                    }
                                    else if (Y.Find("Sprite").GetChild(0).GetComponent<UILabel>().text == "必赢局")
                                    {
                                        ncb10.RNumrateF = 9.8f;
                                    }
                                    else
                                    {
                                        ncb10.RNumrateF = float.Parse(Y.Find("Sprite").GetChild(0).GetComponent<UILabel>().text);
                                    }
                                    ncb10.RNumrateS = 10f;



                                    NetServices.Instance.Send<CL_Cmd_HandleGailv>(ncb10);
                                    //NetServices.Instance.Send<CL_Cmd_HandleGailv>(ncb11);
                                    GlobalHallUIMgr.Instance.ShowSystemTipsUI("修改成功", 2f, false);
                                }
                            }
                            count = 0;
                        }
                        break;
                }
                break;
            case "cancel":
                this.gameObject.SetActive(false);
                break;
        }
    }
}
