using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChosse : MonoBehaviour {
	public GameObject ooo;
	public List<Transform>list=new List<Transform> ();
	// Use this for initialization
	void Start () {

		foreach (Transform a in ooo.transform) {
			list.Add (a);
		}
//		UIEventListener.Get (list [0].gameObject).onClick = ONEPRESS;
//		UIEventListener.Get (list [1].gameObject).onClick = TWOPRESS;
//		UIEventListener.Get (list [2].gameObject).onClick = THREEPRESS;
//		UIEventListener.Get (list [3].gameObject).onClick = FOURPRESS;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TT()
	{
		ooo.transform.parent.gameObject.SetActive(false);
	}
//	void ONEPRESS(GameObject sprite)
//	{
//		ooo.transform.parent.gameObject.SetActive(false);
//	}
//	void TWOPRESS(GameObject sprite)
//	{
//		ooo.transform.parent.gameObject.SetActive(false);
//	}
//	void THREEPRESS(GameObject sprite)
//	{
//		ooo.transform.parent.gameObject.SetActive(false);
//	}
//	void FOURPRESS(GameObject sprite)
//	{
//		GameObject.Find ("SceneUIRoot").transform.Find ("ParentPanel").transform.Find ("HallRoomWind(Clone)").gameObject.SetActive(false) ;
//	}
}
