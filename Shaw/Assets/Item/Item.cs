using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemInfo;
    public string itemSpritePath;
    public string weaponPrefabPath;
    public int usable;
    public int wearable;
    public int weight,number,type;
    //public int MAG,DEF,INT,STR,DEX,LUK,ATK;
    public Mod MAG = new Mod(0, 0);
    public Mod DEF = new Mod(0, 0);
    public Mod DEX = new Mod(0, 0);
    public Mod LUK = new Mod(0, 0);
    public Mod ATK = new Mod(0, 0);
    public Mod VIT = new Mod(0, 0);
    public Mod MAN = new Mod(0, 0);
    public int L_INT, L_STR;
    public int rarity;

    //Need restore UI sprite, Item prefab path.
    public virtual void Shoot()
    {
        return;
    }
}
