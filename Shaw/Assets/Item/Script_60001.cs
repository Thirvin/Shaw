using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_60001 : Item
{
    private void Awake()
    {
        itemName = "石頭";
        itemInfo = "地板上很多";
        itemSpritePath = "Sprites/GUI_Parts/Icons/skill_icon_03";
        weaponPrefabPath = "Weapons/Rocks/Rocks";
        wearable = 6;

        ATK.value = 1;
    }
}
