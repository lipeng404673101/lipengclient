using UnityEngine;
using System.Collections.Generic;

public class PlayerData
{
    public string   Name;
    public uint     ID;         //玩家ID
    public byte     Level;      //等级
    public uint     ImgCrc;     //头像CRC
    public int      GoldNum;    //金币数量
    public string ImageUrl = "http://wx.qlogo.cn/mmopen/EVxJeWK7jLpxBAzboIO94qNehTn1TBhC4KjMFhBj7sQfNfJrpPTue6Ph869ccPU4cVUu6KvT17LRTR5OtRfDjicyqCGib7ricH1/0";   //头像的连接
}
public class PlayerExtraData
{
    public PlayerData playerData = new PlayerData();
}



