using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIItem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(InventoryManager.Instance.currentRightClickMenu != null)
            {
                Destroy(InventoryManager.Instance.currentRightClickMenu);              
            }
            InventoryManager.Instance.currentRightClickMenu = Instantiate(InventoryManager.Instance.rightClickMenuPrefab, Input.mousePosition, transform.rotation, InventoryManager.Instance.inventoryCanvas.transform);
            GameObject rightClickMenu = InventoryManager.Instance.currentRightClickMenu;
            Item item = GetComponent<Item>();
            InventoryManager.Instance.uIItem = this;
            InventoryManager.Instance.item = item;
            if(item.wearable != 0)
            {
                Instantiate(InventoryManager.Instance.eqipButtonPrefab, rightClickMenu.transform);
            }
            else if (item.usable != 0)
            {
                Instantiate(InventoryManager.Instance.putInPropsButtonPrefab, rightClickMenu.transform);
            }
            Instantiate(InventoryManager.Instance.dropButtonPrefab, rightClickMenu.transform);
        }
    }

}
