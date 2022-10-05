using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRightClick : MonoBehaviour
{
    public void Equip()
    {
        if(InventoryManager.Instance.item.wearable == 6)
        {
            InventoryManager.Instance.playerIventory.Switch_weapon(InventoryManager.Instance.item);
        }
        else
        {
            InventoryManager.Instance.playerIventory.Equip_armor(InventoryManager.Instance.item);
        }
        Destroy(InventoryManager.Instance.currentRightClickMenu);
    }

    public void PutInProps()
    {
        InventoryManager.Instance.playerIventory.PutInProps(InventoryManager.Instance.item);
        Destroy(InventoryManager.Instance.currentRightClickMenu);
    }

    public void Drop()
    {
        InventoryManager.Instance.playerIventory.DropDown(InventoryManager.Instance.item);
        Destroy(InventoryManager.Instance.currentRightClickMenu);
    }
}
