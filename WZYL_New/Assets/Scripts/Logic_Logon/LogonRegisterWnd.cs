using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// 注册
/// </summary>
public class LogonRegisterWnd 
{
    GameObject m_gownd;
    UIInput m_uiinputaccount;
    UIInput m_uiinputps1;
    UIInput m_uiinputps2;
    UIInput m_invate;
    public static string aaa;
    public void Init(Object obj)
    {      
        m_gownd = GameObject.Instantiate(obj) as GameObject;
        m_gownd.transform.SetParent(SceneObjMgr.Instance.UIPanelTransform, false);

        UIEventListener.Get(m_gownd.transform.GetChild(0).gameObject).onClick = EventClose;
        UIEventListener.Get(m_gownd.transform.GetChild(1).gameObject).onClick = EventReg;

        m_uiinputaccount = m_gownd.transform.GetChild(2).gameObject.GetComponent<UIInput>();
        m_uiinputps1 = m_gownd.transform.GetChild(3).gameObject.GetComponent<UIInput>();
        m_uiinputps2 = m_gownd.transform.GetChild(4).gameObject.GetComponent<UIInput>();
        m_invate = m_gownd.transform.GetChild(6).gameObject.GetComponent<UIInput>();


    }
    void EventReg(GameObject go)
    {
        if(m_uiinputaccount.value.Length==0)
        {
            return;
        }
        if (m_uiinputps1.value.Length == 0)
        {
            return;
        }
        if (m_uiinputps2.value.Length == 0)
        {
            return;
        }
        if (m_invate.value.Length == 0)
        {
            GlobalHallUIMgr.Instance.ShowSystemTipsUI("邀请码无能为空", 0.5f, false);
            return;
        }
        if (m_invate.value.Length >= 7)
        {
            GlobalHallUIMgr.Instance.ShowSystemTipsUI("邀请码长度过长", 0.5f, false);
            return;
        }

        if (m_uiinputps1.value!=m_uiinputps2.value)
        {
            GlobalHallUIMgr.Instance.ShowSystemTipsUI(StringTable.GetString("UOM_Logon_Register_psnotsame"), 0.5f, false);           
            return;
        }
       
        ShutDown();
        AccountInfo rd = new AccountInfo();
        rd.UID = m_uiinputaccount.value;
        rd.PWD = m_uiinputps1.value;
        rd.INVATE_NUM = m_invate.value;
        
        GlobalEffectMgr.Instance.ShowLoadingMessage();
        LogonRuntime.LogonLogic.RegisterLogon(rd);            
    }
    void EventClose(GameObject go)
    {
        ShutDown();
        LogonRuntime.LogonLogicUI.ChangeLogonWnd(LogonWnd_Status.LogonWnd_Init);
    }
    public void ShutDown()
    {
        if (m_gownd != null)
        {
            GameObject.Destroy(m_gownd);
            m_gownd = null;
        }
    }
	
}
