using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiuNiu : MonoBehaviour {
    public GameObject NiuniuControlWnd;
    //public GameObject Sprite;
    //private int Count = 1;
    //public List<string> Niu;
    //private bool Panl = false;
	// Use this for initialization
	void Start () {
        NiuniuControlWnd.SetActive(false);

        //UIEventListener.Get(Sprite).onClick = AllBtn;
        //namelist.NiuNiuname();
        //Niu = namelist.NiuNiuName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickBtn()
    {
        NiuniuControlWnd.SetActive(true);
    }
    //void AllBtn(GameObject obj)
    //{
    //    string label = this.transform.GetChild(0).GetComponent<UILabel>().text;
    //    switch (label)
    //    {
    //        case "牛牛":
    //            Transform jia = obj.transform.parent.parent.parent;
    //            foreach (Transform Child in jia)
    //            {
    //                if (Child.name == "xianshi")
    //                {
    //                    Child.gameObject.SetActive(true);
    //                }
    //            }
    //            break;
    //    }
        //if (!Panl)
        //{
        //    for (int i = 0; i < Count; i++)
        //    {
        //        GameObject Obj = Instantiate(Resources.Load("Skill")) as GameObject;
        //        Obj.transform.parent = Sprite.transform.GetChild(1).GetChild(0);
        //        Obj.transform.localPosition = Vector3.zero;
        //        Obj.transform.localScale = Vector3.one;
        //        Obj.transform.GetChild(0).GetComponent<UILabel>().text = Niu[i];
        //        Panl = true;
        //    }
        //}
        //else
        //{
        //    foreach(Transform Child in Sprite.transform.Find("Control").GetChild(0).transform)
        //    {
        //        GameObject.Destroy(Child.gameObject);
        //        Panl = false;
        //    }
        //}
    //}
   
}
