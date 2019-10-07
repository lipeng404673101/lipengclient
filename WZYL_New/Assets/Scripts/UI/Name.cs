using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name : MonoBehaviour {
    public UILabel lab;
    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lab.text = PlayerRole.Instance.RoleInfo.RoleMe.GetNickName();
        if (GameObject.Find("BulletLauncher0(Clone)") != null)
        {
            obj.SetActive(false);
        }
	}

}
