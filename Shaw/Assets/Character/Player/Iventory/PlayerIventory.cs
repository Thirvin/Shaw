using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIventory : MonoBehaviour
{
    Player player;

    public GameObject testingItemGameObject;
    public GameObject testingItemGameObject2;
    public GameObject testingItemGameObject3;
    public GameObject testingItemGameObject4;
    private void Start()
    {
        player = GetComponent<Player>();
        player.changeInventoryState += ChangeInventoryState;
        InventoryManager.Instance.playerIventory = this;
    }
    private void Update()
    {
        //For testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(testingItemGameObject != null)
                Pickup(testingItemGameObject, testingItemGameObject.GetComponent<Item>());
            else if(testingItemGameObject2 != null)
                Pickup(testingItemGameObject2, testingItemGameObject2.GetComponent<Item>());
            else if(testingItemGameObject3 != null)
                Pickup(testingItemGameObject3, testingItemGameObject3.GetComponent<Item>());
            else if(testingItemGameObject4 != null)
                Pickup(testingItemGameObject4, testingItemGameObject4.GetComponent<Item>());
        }
    }
    public void Pickup(GameObject itemGameObject, Item item)
    {
        if(item.weight + InventoryManager.Instance.now_weight <= InventoryManager.Instance.max_weight)
        {
            //Cuz the itemGameObject will be deleted, so we can't directly restore "item"
            //We need another way to restore, example: Add the "item" into itemUI
            InventoryManager.Instance.now_weight += item.weight;

            GameObject itemUIGameObject = Instantiate(InventoryManager.Instance.itemUIPrefab, InventoryManager.Instance.bagContentUI.transform);            
            Item UIItem = itemUIGameObject.AddComponent(item.GetType()) as Item;
            //Need add some functions to set up ItemUI
            UIItem ItemUI = itemUIGameObject.GetComponent<UIItem>();
            if(UIItem.itemSpritePath != null)
            {
                ItemUI.itemImage.sprite = Resources.Load<Sprite>(UIItem.itemSpritePath);
            }
            if (UIItem.itemName != null)
                ItemUI.itemName.text = UIItem.itemName;
            InventoryManager.Instance.bag.Add(UIItem);



            Destroy(itemGameObject);
        }
        else
        {
            //show player that bag is full
        }
    }

    public void DropDown(Item item)
    {
        InventoryManager.Instance.now_weight -= item.weight;
        InventoryManager.Instance.bag.Remove(item);

        Destroy(item.gameObject);
        //Need Add a function to spawn dropped item on the floor
    }
    public void Equip_armor(Item armor)
    {
        //equip the armor
        InventoryManager.Instance.equiments[armor.wearable - 1] = armor;

        InventoryManager.Instance.ItemAddMod(armor);
        Debug.Log(PlayerManager.Instance.player.ATK.F_value);
    }
    public void Switch_weapon(Item weapon)
    {
        //change weapon id
        InventoryManager.Instance.equiments[weapon.wearable - 1] = weapon;

        InventoryManager.Instance.ItemAddMod(weapon);

        if(player.weapon != null)
        {
            Destroy(player.weapon.gameObject);
        }
        Instantiate(Resources.Load(weapon.weaponPrefabPath), player.transform);        
    }

    public void Unequip()
    {

    }
    public void PutInProps(Item prop)
    {
        InventoryManager.Instance.props[prop.usable - 1] = prop;
    }

    public void TakeOutProps()
    {

    }

    public void ChangeInventoryState()
    {
        InventoryManager.Instance.bagUI.SetActive(!InventoryManager.Instance.bagUI.activeSelf);
        InventoryManager.Instance.equipmentsUI.SetActive(!InventoryManager.Instance.equipmentsUI.activeSelf);
        InventoryManager.Instance.backgroundUI.SetActive(!InventoryManager.Instance.backgroundUI.activeSelf);
    }
}
