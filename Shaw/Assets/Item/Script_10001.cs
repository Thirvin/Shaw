using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_10001: Item
{
    private void Awake()
    {
        wearable = 1;
    }
    public override void Shoot()
    {
        Debug.Log("SHOOT");
    }
}
