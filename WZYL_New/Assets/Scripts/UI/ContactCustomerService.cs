using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;



public class ContactCustomerService : MonoBehaviour {
    public GameObject FriendSysWidget0;
    public UIInput inputLab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Btn()
    {
        GlobalAudioMgr.Instance.PlayOrdianryMusic(Audio.OrdianryMusic.m_BtnMusic);
        GlobalHallUIMgr.Instance.ShowSystemTipsUI("已提交", 1, false);
      //  FriendSysMgr.ShutDown
       string path = "D:\\ak.txt";
        FileStream fs = new FileStream(path, FileMode.Append);
        StreamWriter sw = new StreamWriter(fs);
        //开始写入
        sw.Write(" \n"+inputLab.value);
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
    }
}
