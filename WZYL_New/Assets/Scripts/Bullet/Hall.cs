using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall : MonoBehaviour {

    public static GameObject headWind;
    private void Start() {
        headWind = GameObject.Find("HeadWind(Clone)");
    }
    public void Niuniu() {
        GlobalAudioMgr.Instance.PlayOrdianryMusic(Audio.OrdianryMusic.m_BtnMusic);
        PlayerRole.Instance.RoleMiNiGame.m_NiuNiuGame.OnJoinRoom();
        GlobalHallUIMgr.Instance.GameShare.EnterGame();

        HallLoginUI_Btns.type = TYPECONTROL.NIUNIU;
        byte[] byteArray = System.Text.Encoding.Default.GetBytes("0");
        Debug.Log(PlayerRole.Instance.RoleInfo.RoleMe.GetGlobel());
        CL_Cmd_CheckClientInfo ncb = new CL_Cmd_CheckClientInfo();
        ncb.SetCmdType(NetCmdType.CMD_CL_CheckClientInfo);
        ncb.RankValue = 0;
        ncb.MachineCode = byteArray;
        ncb.dwUserID = (uint)PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
        ncb.dwGlobeNum = (uint)PlayerRole.Instance.RoleInfo.RoleMe.GetGlobel();
        NetServices.Instance.Send<CL_Cmd_CheckClientInfo>(ncb);
    }
    public void Senlin() {
        GlobalAudioMgr.Instance.PlayOrdianryMusic(Audio.OrdianryMusic.m_BtnMusic);
        PlayerRole.Instance.RoleMiNiGame.m_DialGame.OnJoinRoom();
        GlobalHallUIMgr.Instance.GameShare.EnterGame();
        HallLoginUI_Btns.type = TYPECONTROL.SENLIN;
        byte[] byteArray = System.Text.Encoding.Default.GetBytes("0");
        Debug.Log(PlayerRole.Instance.RoleInfo.RoleMe.GetGlobel() + "where is this????");//玩家身上携带的金币
        CL_Cmd_CheckClientInfo ncb = new CL_Cmd_CheckClientInfo();
        ncb.SetCmdType(NetCmdType.CMD_CL_CheckClientInfo);
        ncb.RankValue = 0;
        ncb.MachineCode = byteArray;
        ncb.dwUserID = (uint)PlayerRole.Instance.RoleInfo.RoleMe.GetUserID();
        ncb.dwGlobeNum = (uint)PlayerRole.Instance.RoleInfo.RoleMe.GetGlobel();
        NetServices.Instance.Send<CL_Cmd_CheckClientInfo>(ncb);
    }
    public void Buyu() {

        GlobalAudioMgr.Instance.PlayOrdianryMusic(Audio.OrdianryMusic.m_BtnMusic);
        HallRunTimeInfo.Instance_UI.m_loginUi.ChangeHallWind(HallLogicUIStatue.Hall_State.Hall_SelectRoom);

    }
}
