using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XIUButton : MonoBehaviour
{
    public GameObject prefab;
    public UIGrid grid;
	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
        grid = this.transform.parent.parent.parent.parent.transform.Find("startinput").transform.GetChild(0).GetChild(0).GetComponent<UIGrid>();
        UIEventListener.Get(this.gameObject).onClick = ButtonSkill;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ButtonSkill(GameObject a)
    {
        switch(int.Parse(a.transform.GetChild(0).GetComponent<UILabel>().text))
        {
            case 1:
                skillplane.panl = 1;
                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(false);
                    }
                }
                GameObject obj = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                Debug.Log(PlayerRole.Instance.RoleInfo.RoleMe.GetUserID());
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }
                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
                    GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
                grid.GetChild(0).gameObject.SetActive(true);
                grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("UserID");
                grid.GetChild(1).gameObject.SetActive(true);
                grid.GetChild(1).GetComponent<UILabel>().text = StringTable.GetString("Goldbel");
                obj.transform.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("GoldAdd");

                break;
            case 2:
                skillplane.panl = 2;
                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(false);
                    }
                }
                GameObject obj1 = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }
                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
                    GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
                grid.GetChild(0).gameObject.SetActive(true);
                grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("UserID");
                grid.GetChild(1).gameObject.SetActive(true);
                grid.GetChild(1).GetComponent<UILabel>().text = StringTable.GetString("ClientID");
                grid.GetChild(2).gameObject.SetActive(true);
                grid.GetChild(2).GetComponent<UILabel>().text = StringTable.GetString("ClodTime");
                obj1.transform.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("Remove");
                break;
            case 3:
                skillplane.panl = 3;
                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(false);
                    }
                }
                GameObject obj2 = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }
                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
                    GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
                grid.GetChild(0).gameObject.SetActive(true);
                grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("UserID");
                grid.GetChild(1).gameObject.SetActive(true);
                grid.GetChild(1).GetComponent<UILabel>().text = StringTable.GetString("Name");
                obj2.transform.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("ModifyName");
                break;
            //case 4:
            //    skillplane.panl = 4;
            //    if (grid.transform.parent.transform.Find("mei") != null)
            //    {
            //        grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
            //    }
            //    if (grid.transform.parent.transform.Find("zaixian") != null)
            //    {
            //        grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
            //    }
            //    for (int i = 0; i < 6; i++)
            //    {
            //        grid.GetChild(i).gameObject.SetActive(false);
            //    }
            //    if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
            //        GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
            //    grid.GetChild(0).gameObject.SetActive(true);
            //    grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("UserID");
            //    grid.GetChild(1).gameObject.SetActive(true);
            //    grid.GetChild(1).GetComponent<UILabel>().text = StringTable.GetString("Password");
            //    grid.GetChild(2).gameObject.SetActive(true);
            //    grid.GetChild(2).GetComponent<UILabel>().text = StringTable.GetString("Password");
            //    grid.GetChild(3).gameObject.SetActive(true);
            //    grid.GetChild(3).GetComponent<UILabel>().text = StringTable.GetString("Password");
            //    break;
            case 4:
                skillplane.panl = 4;
                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(false);
                    }
                }
                GameObject objz = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }
                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
                    GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
                grid.GetChild(0).gameObject.SetActive(true);
                grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("GongGao");
                objz.transform.GetChild(0).GetComponent<UILabel>().text = "填写要发送的信息";
                break;
            case 5:
                skillplane.panl = 5;
                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(false);
                    }
                }
                GameObject objw = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }
                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
                    GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
                grid.GetChild(0).gameObject.SetActive(true);
                grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("ClientID");
                objw.transform.GetChild(0).GetComponent<UILabel>().text = "填写用户ID不是游戏ID";
                break;
            case 6:
                skillplane.panl = 6;
                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(false);
                    }
                }
                GameObject objs = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }
                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
                    GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
                grid.GetChild(0).gameObject.SetActive(true);
                grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("UserID");
                grid.GetChild(1).gameObject.SetActive(true);
                grid.GetChild(1).GetComponent<UILabel>().text = StringTable.GetString("ClientID");
                objs.transform.GetChild(0).GetComponent<UILabel>().text = "填写用户ID和游戏ID";
                break;
            case 7:
                skillplane.panl = 7;
                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(false);
                    }
                }
                GameObject objy = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }
                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                Transform TX = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)");
                foreach (Transform Plan in TX)
                {
                    if (Plan.name == "Tishi")
                    {
                        Plan.gameObject.SetActive(true);
                    }
                }
                objy.transform.GetChild(0).GetComponent<UILabel>().text = "直接点击确定就好";
                break;
            //case 9:
            //    skillplane.panl = 9;
            //    Debug.Log("经过这里");
            //    if (grid.transform.parent.transform.Find("mei") != null)
            //    {
            //        grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
            //    }
            //    if (grid.transform.parent.transform.Find("zaixian") != null)
            //    {
            //        grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
            //    }
            //    for (int i = 0; i < 6; i++)
            //    {
            //        grid.GetChild(i).gameObject.SetActive(false);
            //    }
            //    Transform TX1 = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)");
            //    foreach (Transform Plan in TX1)
            //    {
            //        if (Plan.name == "Tishi")
            //        {
            //            Plan.gameObject.SetActive(true);
            //        }
            //    }
               
            //    break;
            //case 10:
            //    skillplane.panl = 10;
            //    if (grid.transform.parent.transform.Find("mei") != null)
            //    {
            //        grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
            //    }
            //    if (grid.transform.parent.transform.Find("zaixian") != null)
            //    {
            //        grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
            //    }
            //    for (int i = 0; i < 6; i++)
            //    {
            //        grid.GetChild(i).gameObject.SetActive(false);
            //    }
            //    Transform TX2 = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)");
            //    foreach (Transform Plan in TX2)
            //    {
            //        if (Plan.name == "Tishi")
            //        {
            //            Plan.gameObject.SetActive(true);
            //        }
            //    }
            //    break;
            case 8:
                skillplane.panl = 8;

                foreach (Transform pp in GameObject.Find("SceneUIRoot").transform.Find("ParentPanel").transform.Find("ShopSysWndUI001(Clone)"))
                {
                    if (pp.name == "zuile")
                    {
                        pp.gameObject.SetActive(true);
                    }
                }
                GameObject obj10 = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Sprite").gameObject;
                if (grid.transform.parent.transform.Find("mei") != null)
                {
                    grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
                }
                if (grid.transform.parent.transform.Find("zaixian") != null)
                {
                    grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
                }

                for (int i = 0; i < 6; i++)
                {
                    grid.GetChild(i).gameObject.SetActive(false);
                }
                if (GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi") != null)
                    GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)").transform.Find("Tishi").gameObject.SetActive(false);
                //grid.GetChild(0).gameObject.SetActive(true);
                //grid.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("JCBL");
                //grid.GetChild(1).gameObject.SetActive(true);
                //grid.GetChild(1).GetComponent<UILabel>().text = StringTable.GetString("ZDBL");
                //obj10.transform.GetChild(0).GetComponent<UILabel>().text = StringTable.GetString("Panl");
                break;
            //case 12:
            //    skillplane.panl = 12;
            //    if (grid.transform.parent.transform.Find("mei") != null)
            //    {
            //        grid.transform.parent.transform.Find("mei").gameObject.SetActive(false);
            //    }
            //    if (grid.transform.parent.transform.Find("zaixian") != null)
            //    {
            //        grid.transform.parent.transform.Find("zaixian").gameObject.SetActive(false);
            //    }
            //    for (int i = 0; i < 6; i++)
            //    {
            //        grid.GetChild(i).gameObject.SetActive(false);
            //    }
            //    Transform TX4 = GameObject.Find("SceneUIRoot").transform.GetChild(1).transform.Find("ShopSysWndUI001(Clone)");
            //    foreach (Transform Plan in TX4)
            //    {
            //        if (Plan.name == "Tishi")
            //        {
            //            Plan.gameObject.SetActive(true);
            //        }
            //    }
                
            //    break;
        }

    }
}
