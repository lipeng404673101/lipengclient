using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class skillplane : MonoBehaviour
{
    public TextAsset Text;
    public GameObject Prefab;
    public GameObject XiuGai;
    public UIGrid grid;
    public static bool UserAgent = false;
    [HideInInspector]
    public static int panl = 0;
    public List<string> XG;


    //public UIInputNum num;

    //private UIInput inputText;
    //float num = 0;
    // Use this for initialization
    void Start()
    {
        namelist.Name();
        XG = namelist.name;
        string Assast = Text.ToString();
        string[] count = Assast.Split('\n');
        m_Creat(count);
        UIEventListener.Get(XiuGai).onClick = m_XiuGai;
        UIEventListener.Get(this.transform.GetChild(2).gameObject).onClick = Backbtn;
    }

    // Update is called once per frame

    private void Update()
    {

    }
    void m_Creat(string[] a)
    {

        for (int i = 0; i < a.Length; i++)
        {
            GameObject obj = Instantiate(Prefab) as GameObject;
            obj.transform.parent = grid.transform;
            obj.transform.localScale = Vector3.one;
            obj.transform.GetChild(0).GetComponent<UILabel>().text = a[i];
            obj.transform.GetChild(1).GetComponent<UILabel>().text = XG[i];
        }
    }
    void Backbtn(GameObject obj)
    {
        GameObject.Destroy(this.gameObject);
        GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("HallWindBtns(Clone)").GetChild(0).GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(true);

    }

    void m_XiuGai(GameObject obj)
    {
        switch (panl)
        {
            case 1://加金币
                int userID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text);
                double GlobalNum = double.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text);


                CL_Cmd_ChangeUserGold ncb1 = new CL_Cmd_ChangeUserGold();
                ncb1.SetCmdType(NetCmdType.CMD_CL_ChangeUserGold);
                ncb1.UserIDself = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                ncb1.UserID = (uint)userID;
                ncb1.GlobalNum = (uint)(GlobalNum * 1000);
                ncb1.bIsZongDai = UserAgent;
                NetServices.Instance.Send<CL_Cmd_ChangeUserGold>(ncb1);


                break;
            case 2://封号、时间(完成)
                int UserID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text);
                int ClientID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text);
                int FreeClod = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<UILabel>().text);
                CL_Cmd_KickUserByID ncb = new CL_Cmd_KickUserByID();
                ncb.SetCmdType(NetCmdType.CMD_CL_KickUserByID);
                ncb.UserID = (uint)UserID;
                ncb.ClientID = (uint)ClientID;
                ncb.FreezeMin = (uint)FreeClod;
                NetServices.Instance.Send<CL_Cmd_KickUserByID>(ncb);
                break;
            case 3://修改名字(完成)
                int SelfID = (int)PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                int UserIID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text);
                string Name = obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text;
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
                break;
            //case 4://修改用户的密码
            //    int UseID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text);
            //    int Passwordone = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text);
            //    int Passwordtwo = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<UILabel>().text);
            //    int Passwordthree = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<UILabel>().text);
            //    CL_Cmd_ResetRolePassword ncb3 = new CL_Cmd_ResetRolePassword();
            //    ncb3.SetCmdType(NetCmdType.CMD_CL_ResetRolePassword);
            //    ncb3.RankValue = (uint)UseID;
            //    ncb3.Passworldone = (uint)Passwordone;
            //    ncb3.Passworldtwo = (uint)Passwordtwo;
            //    ncb3.Passworldthree = (uint)Passwordthree;
            //    NetServices.Instance.Send<CL_Cmd_ResetRolePassword>(ncb3);
            //    break;
            case 4://发送全服公告(完成)
                Debug.Log("我知道发送了这里");
                string CenterMessage = obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                CL_Cmd_SendMsgToAllGame ncb4 = new CL_Cmd_SendMsgToAllGame();
                ncb4.SetCmdType(NetCmdType.CMD_CL_SendMsgToAllGame);
                ncb4.Param = 12;
                ncb4.MessageColor = 4294967295;
                ncb4.StepNum = 3;
                ncb4.StepSec = 30;
                ncb4.MessageSize = UInt16.Parse(CenterMessage.Length.ToString());
                Debug.Log("发送消息：" + CenterMessage.ToString());
                ncb4.CenterMessage = CenterMessage.ToString();
                NetServices.Instance.Send<CL_Cmd_SendMsgToAllGame>(ncb4);
                break;
            case 5://查询库存（完成）

                CL_Cmd_QueryFishPool ncb5 = new CL_Cmd_QueryFishPool();
                ncb5.SetCmdType(NetCmdType.CMD_CL_QueryFishPool);
                ncb5.UserID = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
                NetServices.Instance.Send<CL_Cmd_QueryFishPool>(ncb5);
                break;
            case 6://查询在线玩家（完成）****更改为修改库存
                //int dwUserID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text);
                //int clientID = int.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text);
                //CL_Cmd_QueryOnlineUserInfo ncb6 = new CL_Cmd_QueryOnlineUserInfo();
                //ncb6.SetCmdType(NetCmdType.CMD_CL_QueryOnlineUserInfo);
                //ncb6.UserId = (uint)dwUserID;
                //ncb6.NULL = (uint)clientID;
                //NetServices.Instance.Send<CL_Cmd_QueryOnlineUserInfo>(ncb6);
                //string UserId = obj.transform.parent.transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                string value = obj.transform.parent.transform.GetChild(6).GetChild(1).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                string tableId = obj.transform.parent.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text;
                CL_Cmd_HandleTablePoolGailv ncb51 = new CL_Cmd_HandleTablePoolGailv();
                ncb51.SetCmdType(NetCmdType.Cmd_CL_HandleTablePoolGailv);
                ncb51.nValue = double.Parse(value) * 1000;
                ncb51.TableID = byte.Parse(tableId);
                NetServices.Instance.Send<CL_Cmd_HandleTablePoolGailv>(ncb51);
                break;
            case 7://更新配置表(完成)
                CL_Cmd_ReloadConfig ncb7 = new CL_Cmd_ReloadConfig();
                ncb7.SetCmdType(NetCmdType.CMD_CL_ReloadConfig);
                NetServices.Instance.Send<CL_Cmd_ReloadConfig>(ncb7);
                break;
            //case 9://查询黑名单
            //    CL_Cmd_QueryBlackList ncb8 = new CL_Cmd_QueryBlackList();
            //    ncb8.SetCmdType(NetCmdType.CMD_CL_QueryBlackList);
            //    NetServices.Instance.Send<CL_Cmd_QueryBlackList>(ncb8);
            //    break;
            //case 10://设置黑名单
            //    CL_Cmd_SetBlackList ncb9 = new CL_Cmd_SetBlackList();
            //    ncb9.SetCmdType(NetCmdType.CMD_CL_SetBlackList);
            //    NetServices.Instance.Send<CL_Cmd_SetBlackList>(ncb9);
            //    break;
            case 8://修改倍率
                   //if (obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text == ""|| obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text=="")
                   //{
                   //    GlobalHallUIMgr.Instance.ShowSystemTipsUI("信息错误", 2f, false);
                   //}
                   //else
                   //{
                   //    float F = float.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UILabel>().text);
                   //    float S = float.Parse(obj.transform.parent.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<UILabel>().text);
                   //    float a = 0.001f;
                   //    float b = 5;
                   //    if ( F > b || S >= b || S <= F|| S <= a || F <= a )
                   //    {
                   //        GlobalHallUIMgr.Instance.ShowSystemTipsUI("信息错误", 2f, false);
                   //    }
                   //    else
                   //    {
                GameObject obj12 = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                string xixi = obj12.transform.GetChild(0).GetComponent<UILabel>().text;
                CL_Cmd_HandleGailv ncb10 = new CL_Cmd_HandleGailv();
                ncb10.SetCmdType(NetCmdType.CMD_CL_HandleGailv);
                switch (buttons.panl)
                {
                    case "1档":

                        ncb10.RNumrateF = 0.3f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "2档":
                        ncb10.RNumrateF = float.Parse(CenterControl.num);//0.04
                        ncb10.RNumrateS = 100f;// 0.5f;

                        break;
                    case "3档":
                        ncb10.RNumrateF = 2.5f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "4档":
                        ncb10.RNumrateF = 0.9f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "5档":
                        ncb10.RNumrateF = 1.0f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "6档":
                        ncb10.RNumrateF = 3.0f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "7档"://必输档
                        ncb10.RNumrateF = 0.1f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "8档":
                        ncb10.RNumrateF = 1.5f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "9档"://必赢档
                        ncb10.RNumrateF = 9.8f;
                        ncb10.RNumrateS = 10f;

                        break;
                    case "10档":
                        ncb10.RNumrateF = 2.0f;
                        ncb10.RNumrateS = 10f;
                        break;
                }
                NetServices.Instance.Send<CL_Cmd_HandleGailv>(ncb10);
                GlobalHallUIMgr.Instance.ShowSystemTipsUI("修改成功", 2f, false);
                //    }
                //}
                break;
                //case 12://修改库存
                //    CL_Cmd_ChangeTablePool ncb11 = new CL_Cmd_ChangeTablePool();
                //    ncb11.SetCmdType(NetCmdType.CMD_CL_ChangeTablePool);
                //    ncb11.TableID = 1;
                //    ncb11.nValue = 100;
                //    NetServices.Instance.Send<CL_Cmd_ChangeTablePool>(ncb11);
                //    break;

        }


    }

}
