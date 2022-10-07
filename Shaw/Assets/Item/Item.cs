using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemInfo;
    public string itemSpritePath;
    public int usable;
    public int wearable;
    public int weight,number,type;
    public int MAG,DEF,INT,STR,DEX,LUK,ATK;
    public int L_MAG,L_DEF,L_INT,L_STR,L_DEX,L_LUK,L_ATK;
    public int rarity;

    //Need restore UI sprite, Item prefab path.
    public virtual void Shoot()
    {
        return;
    }
}
