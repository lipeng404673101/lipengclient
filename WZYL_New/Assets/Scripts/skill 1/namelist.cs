using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class namelist : MonoBehaviour {
    public static List<string> name = new List<string>();
    public static void Name()
    {
        name.Add("修改金币");
        name.Add("踢出玩家");
        name.Add("修改名字");
        //name.Add("修改密码");
        name.Add("发送公告");
        name.Add("查询库存");
        name.Add("在线玩家");
        name.Add("更新配置表");
        //name.Add("查询黑名单");
        //name.Add("设置黑名单");
        name.Add("修改概率");
    }	
}
