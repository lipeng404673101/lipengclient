using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static byte m_RoomID;
    public static bool m_RoomJoin = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Btn() {
        Debug.Log("快速游戏");
        m_RoomJoin = true;
        CL_Cmd_CheckClientDailiBond ncb = new CL_Cmd_CheckClientDailiBond();
        ncb.SetCmdType(NetCmdType.CMD_CL_CheckClientDailiBond);
        ncb.dwUserID = PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
        ncb.dwOtherUserID = 0;
        NetServices.Instance.Send<CL_Cmd_CheckClientDailiBond>(ncb);
        //GameObject.Find("HeadWind(Clone)").SetActive(false);
    }
    public static void JOINROOM()
    {
        GlobalAudioMgr.Instance.PlayOrdianryMusic(Audio.OrdianryMusic.m_BtnMusic);
        byte roomid = PlayerRole.Instance.TableManager.ConvertTableID(m_RoomID);
        Debug.Log("有房间的ID输出" + roomid);
        HallRunTimeInfo.Instance.m_login.JoinRoom(roomid);
        GameObject.Destroy(GameObject.Find("HallRoomWind(Clone)"));
    }
    public static void JOINROOM1()
    {
        GlobalAudioMgr.Instance.PlayOrdianryMusic(Audio.OrdianryMusic.m_BtnMusic);
        byte roomid = PlayerRole.Instance.TableManager.ConvertTableID(m_RoomID);
        HallRunTimeInfo.Instance.m_login.JoinRoom(roomid);
    }
}
