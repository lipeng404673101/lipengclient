using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTime : MonoBehaviour {
    public static float StarTime = 10.0f;
    public static float EndTime = 3.0f;
    public static bool Panl = false;
    [Range(1,10)]
    public int zz;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Panl)
        {
            StarTime -= Time.deltaTime*2f;
            if (StarTime <= 0f)
            {
                Panl = false;
                StarTime = 10.0f;
            }
        }
	}
}
