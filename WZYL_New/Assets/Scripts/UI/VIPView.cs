using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPView : MonoBehaviour {
    public GameObject Vip1;
    public GameObject Vip2;
    public GameObject Vip3;
    public GameObject Vip4;
   // public GameObject Vip5;
  //  public GameObject Vip6; 

	// Use this for initialization
	void Start () {
        Vip1.SetActive(true);
        Vip2.SetActive(false);
        Vip3.SetActive(false);
        Vip4.SetActive(false);
     //   Vip5.SetActive(false);
       // Vip6.SetActive(false);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Vip1
    public void Vip1RightBtn()
    {
        Vip1.SetActive(false);
        Vip2.SetActive(true);
    }

   //Vip2
    public void Vip2LeftBtn()
    {
        Vip1.SetActive(true);
        Vip2.SetActive(false);
    }
    public void Vip2RightBtn()
    {
        Vip2.SetActive(false);
        Vip3.SetActive(true);
    }

    //Vip3
    public void Vip3LeftBtn()
    {
        Vip2.SetActive(true);
        Vip3.SetActive(false);
    }
    public void Vip3RightBtn()
    {
        Vip3.SetActive(false);
        Vip4.SetActive(true);
    }

    //Vip4
    public void Vip4LeftBtn()
    {
        Vip3.SetActive(true);
        Vip4.SetActive(false);
    }
    /*
    public void Vip4RightBtn()
    {
        Vip4.SetActive(false);
        Vip5.SetActive(true);
    }
    
    //Vip5
    public void Vip5LeftBtn()
    {
        Vip4.SetActive(true);
        Vip5.SetActive(false);
    }
    public void Vip5RightBtn()
    {
        Vip5.SetActive(false);
        Vip6.SetActive(true);
    }

    //Vip6
    public void Vip6LeftBtn()
    {
        Vip5.SetActive(true);
        Vip6.SetActive(false);
    }
     * */
}
