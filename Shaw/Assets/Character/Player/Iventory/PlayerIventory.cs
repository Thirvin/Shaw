using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerIventory : MonoBehaviour
{
    Player player;

    public GameObject testingItemGameObject;
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
            Pickup(testingItemGameObject, testingItemGameObject.GetComponent<Item>());
        }
    }
    public void Pickup(GameObject itemGameObject, Item item)
    {
        if(item.weight + InventoryManager.Instance.now_weight <= InventoryManager.Instance.max_weight)
        {
            //Cuz the itemGameObject will be deleted, so we can't directly restore "item"
            //We need another way to restore, example: Add the "item" into itemUI
            InventoryManager.Instance.now_weight += item.weight;

            GameObject itemUI = Instantiate(InventoryManager.Instance.itemUIPrefab, InventoryManager.Instance.bagContentUI.transform);            
            Item UIItem = itemUI.AddComponent(item.GetType()) as Item;
            //Need add some functions to set up ItemUI
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
        //check if able to equip

        //equip the armor

        InventoryManager.Instance.equiments[armor.wearable] = armor;
    }
    public void Switch_weapon(Item weapon)
    {
        //check if able to equip

        //change weapon id
    }
    public void PutInProps(Item prop)
    {
        
    }

    public void ChangeInventoryState()
    {
        InventoryManager.Instance.bagUI.SetActive(!InventoryManager.Instance.bagUI.activeSelf);
        InventoryManager.Instance.equipmentsUI.SetActive(!InventoryManager.Instance.equipmentsUI.activeSelf);
    }
}
