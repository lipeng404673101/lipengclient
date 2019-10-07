using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

    private float shakeTime = 0.0f;
    private float fps = 20.0f;
    private float frameTime = 0.0f;
    private float shakeDelta = 0.005f;
    public Camera cam;
    public static bool isshakeCamera = false;
    // Use this for initialization
    void Start () {
        shakeTime = 2.0f;
        fps = 20.0f;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
    }
	
	// Update is called once per frame
	void Update () {
        if (isshakeCamera)
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                if (shakeTime <= 0)
                {
                    cam.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                    isshakeCamera = false;
                    shakeTime = 2.0f;
                    fps = 30.0f;
                    frameTime = 0.03f;
                    shakeDelta = 0.005f;
                }
                else
                {
                    frameTime += Time.deltaTime;

                    if (frameTime > 1.0 / fps)
                    {
                        frameTime = 0;
                        cam.rect = new Rect(shakeDelta * (-1.0f + 5.0f * Random.value), shakeDelta * (-1.0f + 5.0f * Random.value), 1.0f, 1.0f);
                    }
                }
            }
        }
    }
}
