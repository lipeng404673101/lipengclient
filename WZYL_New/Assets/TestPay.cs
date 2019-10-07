using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPay : MonoBehaviour
{
    public UILabel Tlabel;
    private bool success=true;
    private bool userOnline = true;
    private bool lowuserGold = true;
    private void Start()
    {
        Tlabel = transform.Find("Label").GetComponent<UILabel>();
    } 
    public void PayBtn()
    {
        int goldNum = int.Parse(Tlabel.text);
        CL_Cmd_QRoleDaili daili = new CL_Cmd_QRoleDaili(); 
        daili.SetCmdType(NetCmdType.CMD_CL_QRoleDaili);
        daili.UserID= 965;

        NetServices.Instance.Send<CL_Cmd_QRoleDaili>(daili);
        Debug.Log(daili);
    }
}
