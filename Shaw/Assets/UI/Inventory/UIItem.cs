using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemStatus;

    InventoryToolTip toolTip;

    private void Update()
    {
        if(toolTip != null)
            toolTip.transform.position = Input.mousePosition;
    }
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
            InventoryManager.Instance.selectedUIItem = this;
            InventoryManager.Instance.item = item;
            
            if(itemStatus.text != "E")
            {
                if(item.wearable != 0)
                {
                    Instantiate(InventoryManager.Instance.eqipButtonPrefab, rightClickMenu.transform);
                }
                else if (item.usable != 0)
                {
                    Instantiate(InventoryManager.Instance.putInPropsButtonPrefab, rightClickMenu.transform);
                }
            }
            else
            {
                if (item.wearable != 0)
                {
                    Instantiate(InventoryManager.Instance.unequipmentButtonPrefab, rightClickMenu.transform);
                }
                else if (item.usable != 0)
                {
                    Instantiate(InventoryManager.Instance.takeOutPropsButtonPrefab, rightClickMenu.transform);
                }                
            }
            Instantiate(InventoryManager.Instance.dropButtonPrefab, rightClickMenu.transform);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(toolTip == null)
        {
            Item item = GetComponent<Item>();
            toolTip = Instantiate(InventoryManager.Instance.toolTipPrefab, Input.mousePosition, transform.rotation, InventoryManager.Instance.inventoryCanvas.transform).GetComponent<InventoryToolTip>();
            toolTip.itemName.text = item.itemName;
            toolTip.itemInfo.text = item.itemInfo;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(toolTip != null)
        {
            Destroy(toolTip.gameObject);
        }
    }
}
