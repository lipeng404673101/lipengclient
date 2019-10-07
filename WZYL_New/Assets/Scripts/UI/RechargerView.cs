using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 充值
/// </summary>
public class RechargerView : MonoBehaviour
{

    [SerializeField]
    UILabel InputScoreClass;

    //   public UILabel lab;
    int mRechargType = 0;
    void Start()
    {
    }

    public void OnBtnCommonAmountMoney(int money)
    {
        InputScoreClass.text = money.ToString();
    }

    public void OnBtnRechargeType(int type)
    {
        mRechargType = type;
    }

    //清除按钮
    public void OnBtnClearInput()
    {
        InputScoreClass.text = "请输入充值金额，最低10元";
    }

/*
    public void OnBtnRecharge()
    {
        int score = 0;
        int.TryParse(InputScoreClass.text, out score);
        if (score < 20)
        {
            MessageBox.Show("输入金额必须大于20元！");
            return;
        }
        
        // TODO 
    }
  

    public void CloseBtn()
    {
        GameObject.Find("SceneUIRoot/Panel/Panel/layer_recharge").SetActive(false);
    }
    */
    public void Btn50()
    {
        InputScoreClass.text = "50";
    }
    public void Btn100()
    {
        InputScoreClass.text = "100";
    }
    public void Btn500()
    {
        InputScoreClass.text = "500";
    }
    public void Btn1000()
    {
        InputScoreClass.text = "1000";
    }
    public void Btn3000()
    {
        InputScoreClass.text = "3000";
    }
}