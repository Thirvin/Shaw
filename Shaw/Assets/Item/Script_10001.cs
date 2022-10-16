using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_10001 : Item
{
    private void Awake()
    {
        itemName = "廉價的斧頭";
        itemInfo = "我唯一能買得起的物品";
        wearable = 1;

        ATK.value = 2;
    }
}
