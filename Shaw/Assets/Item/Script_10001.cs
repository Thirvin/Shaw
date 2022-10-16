using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_10001 : Item
{
    private void Awake()
    {
        itemName = "廉價的斧頭";
        itemInfo = "你唯一能買得起的物品";
        wearable = 1;
    }
    public override void Shoot()
    {
        Debug.Log("SHOOT");
    }
}
