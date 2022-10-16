using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_00001 : Item
{
    private void Awake()
    {
        usable = 1;
        itemName = "白開水";
        itemInfo = "多喝";
        itemSpritePath = "Sprites/GUI_Parts/Icons/skill_icon_01";
    }
}
