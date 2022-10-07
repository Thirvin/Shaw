using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryRightClick : MonoBehaviour
{
    public void Equip()
    {
        if(InventoryManager.Instance.selectedUIItem.itemStatus.text == "E")
        {
            Unequip();
        }
        if(InventoryManager.Instance.equipmentUIItems[InventoryManager.Instance.item.wearable - 1] != null)
        {
            //InventoryManager.Instance.equipmentUIItems[InventoryManager.Instance.item.wearable - 1].itemStatus.text = "";
            Unequip();
        }

        if (InventoryManager.Instance.item.wearable == 6)
        {
            InventoryManager.Instance.playerIventory.Switch_weapon(InventoryManager.Instance.item);
        }
        else
        {
            InventoryManager.Instance.playerIventory.Equip_armor(InventoryManager.Instance.item);
        }
        Image equipmentImage = Instantiate(InventoryManager.Instance.equipmentBoxImagePrefab, InventoryManager.Instance.equipmentBoxes[InventoryManager.Instance.item.wearable - 1].transform).GetComponent<Image>();
        equipmentImage.sprite = InventoryManager.Instance.selectedUIItem.itemImage.sprite;
        InventoryManager.Instance.equipmentImages[InventoryManager.Instance.item.wearable - 1] = equipmentImage.gameObject;
        InventoryManager.Instance.selectedUIItem.itemStatus.text = "E";
        InventoryManager.Instance.equipmentUIItems[InventoryManager.Instance.item.wearable - 1] = InventoryManager.Instance.selectedUIItem;
        Destroy(InventoryManager.Instance.currentRightClickMenu);

        //Need function to add item stats on player
    }

    public void PutInProps()
    {
        if (InventoryManager.Instance.selectedUIItem.itemStatus.text == "E")
        {
            TakeOutProps();
        }
        if (InventoryManager.Instance.propUIItems[InventoryManager.Instance.item.usable - 1] != null)
        {
            //InventoryManager.Instance.propUIItems[InventoryManager.Instance.item.usable - 1].itemStatus.text = "";
            TakeOutProps();
        }

        InventoryManager.Instance.playerIventory.PutInProps(InventoryManager.Instance.item);

        Image propImage = Instantiate(InventoryManager.Instance.equipmentBoxImagePrefab, InventoryManager.Instance.propBoxes[InventoryManager.Instance.item.usable - 1].transform).GetComponent<Image>();
        propImage.sprite = InventoryManager.Instance.selectedUIItem.itemImage.sprite;
        InventoryManager.Instance.propImages[InventoryManager.Instance.item.usable - 1] = propImage.gameObject;
        InventoryManager.Instance.selectedUIItem.itemStatus.text = "E";
        InventoryManager.Instance.propUIItems[InventoryManager.Instance.item.usable - 1] = InventoryManager.Instance.selectedUIItem;
        Destroy(InventoryManager.Instance.currentRightClickMenu);
    }

    public void TakeOutProps()
    {
        Destroy(InventoryManager.Instance.propImages[InventoryManager.Instance.item.usable - 1]);
        InventoryManager.Instance.propUIItems[InventoryManager.Instance.item.usable - 1].itemStatus.text = "";
        Destroy(InventoryManager.Instance.currentRightClickMenu);
    }

    public void Unequip()
    {
        Destroy(InventoryManager.Instance.equipmentImages[InventoryManager.Instance.item.wearable - 1]);        
        InventoryManager.Instance.equipmentUIItems[InventoryManager.Instance.item.wearable - 1].itemStatus.text = "";
        Destroy(InventoryManager.Instance.currentRightClickMenu);

        //Need function to remove item stats on player
    }

    public void Drop()
    {
        InventoryManager.Instance.playerIventory.DropDown(InventoryManager.Instance.item);
        if (InventoryManager.Instance.selectedUIItem.itemStatus.text == "E")
        {            
            if (InventoryManager.Instance.item.wearable != 0)
            {
                Unequip();
            }
            else if (InventoryManager.Instance.item.usable != 0)
            {
                TakeOutProps();
            }
        }
        Destroy(InventoryManager.Instance.currentRightClickMenu);
    }
}
