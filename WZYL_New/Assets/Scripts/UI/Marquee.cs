using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 跑马灯效果
/// </summary>
class Marquee : MonoBehaviour
{
    [SerializeField]
    GameObject MoveObject;
    Vector3 mStartPos = new Vector3(800, 0);

    void Start()
    {
        MoveObject.transform.localPosition = mStartPos;
        MoveObject.transform.DOLocalMoveX(-800, 10).SetEase(Ease.Linear).SetRelative();
    }
}