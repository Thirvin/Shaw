using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InventoryManager : MonoBehaviour
{
    public PlayerIventory playerinventory = new PlayerIventory();
    public void switch_weapon (string weapon)
    {
        //playerinventory.weapon = weapon;
        string ID = "Script_"  + weapon;
        gameObject.AddComponent(Type.GetType(ID));
        gameObject.GetComponent<Player>().Weapon_Id = ID;

    }
}
