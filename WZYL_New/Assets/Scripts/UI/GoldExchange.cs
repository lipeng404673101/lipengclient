using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldExchange : MonoBehaviour
{
    public UISlider slider;
    public UILabel lab;
    public UIInput inputLab;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //兑换记录
    public void OnBtnExchangeRecorde()
    {

    }

    //清除
    public void OnBtnClearScore()
    {
        lab.text = "请输入或拖选兑换金额";
        slider.value = 0;
    }

    //输入数值改变滑动条的值
    public void OnBtnInput()
    {
        slider.value = float.Parse(inputLab.text) / 100;
    }

    //滑动条改变数值大小
    public void OnSliderValueChange()
    {
        lab.text = Mathf.Ceil(slider.value * 100).ToString();
    }

    //最大
    public void OnBtnMaxScore()
    {
        slider.value = 1;
        lab.text = "100";
    }

    //绑定支付宝
    public void OnBtnBind()
    {
        GameObject.Find("SceneUIRoot/Panel/Panel/Bind_Zhifubao").SetActive(true);
        GameObject.Find("SceneUIRoot/Panel/Panel/ExchangeScore").SetActive(false);
    }

    //兑换
    public void OnBtnCommitExchg()
    {

    }

    /*
    //关闭
    public void OnClose()
    {
        GameObject.Find("SceneUIRoot/Panel/Panel/ExchangeScore").SetActive(false);
    }
    */
}

