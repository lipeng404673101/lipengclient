using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum TYPECONTROL
{
    None,
    BUYU,
    NIUNIU,
    SENLIN
}
public class werew : MonoBehaviour {
    public AndroidJavaObject activity;
    // Use this for initialization
    void Start () {
        //NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
        //foreach (NetworkInterface ni in nis)
        //{
        //    Debug.Log("Name = " + ni.Name);
        //    Debug.Log("Des = " + ni.Description);
        //    Debug.Log("Type = " + ni.NetworkInterfaceType.ToString());
        //    Debug.Log("Mac = " + ni.GetPhysicalAddress().ToString());
        //    Debug.Log("------------------------------------------------");
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {

        //判断是否是代理，还是超级代理，还是普通用户
        HallLoginUI_Btns.type = TYPECONTROL.BUYU;
        byte[] byteArray = System.Text.Encoding.Default.GetBytes("0");
        Debug.Log(PlayerRole.Instance.RoleInfo.RoleMe.GetGlobel());
        CL_Cmd_CheckClientInfo ncb = new CL_Cmd_CheckClientInfo();
        ncb.SetCmdType(NetCmdType.CMD_CL_CheckClientInfo);
        ncb.RankValue = 0;
        ncb.MachineCode = byteArray;
        ncb.dwUserID = (uint)PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
        ncb.dwGlobeNum = (uint)PlayerRole.Instance.RoleInfo.RoleMe.GetGlobel();
        NetServices.Instance.Send<CL_Cmd_CheckClientInfo>(ncb);
        //foreach (Transform TR in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
        //{
        //    if (TR.name == "Texture")
        //    {
        //        TR.gameObject.SetActive(true);
        //    }
        //}



    }
    public static void Buyu()
    {
        foreach (Transform TR in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)"))
        {
            if (TR.name == "Texture")
            {
                TR.gameObject.SetActive(true);
            }
        }
    }
    public static void SuperDL()
    {
        GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("HallWindBtns(Clone)").GetChild(8).gameObject.SetActive(false);
        GameObject ShopSysWnd = Resources.Load("ShopSysWndUI001") as GameObject;
        GameObject ShopPosition = Instantiate(ShopSysWnd);
        ShopPosition.transform.parent = GameObject.Find("SceneUIRoot").transform.Find("ParentPanel");
        ShopPosition.transform.localPosition = Vector3.zero;
        ShopPosition.transform.localScale = Vector3.one;
        GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("HallWindBtns(Clone)").GetChild(0).GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
    public static void DL()
    {
        GameObject ShopSysWnd = Resources.Load("ShopSysWndUI002") as GameObject;
        GameObject ShopPosition = Instantiate(ShopSysWnd);
        ShopPosition.transform.parent = GameObject.Find("SceneUIRoot").transform.Find("ParentPanel");//設置父物體
        ShopPosition.transform.localPosition = Vector3.zero;//初始化位置
        ShopPosition.transform.localScale = Vector3.one;//初始化大小
        ShopPosition.transform.GetChild(3).GetChild(1).GetComponent<UILabel>().text = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID().ToString();//人物ID
        GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("HallWindBtns(Clone)").GetChild(0).GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
