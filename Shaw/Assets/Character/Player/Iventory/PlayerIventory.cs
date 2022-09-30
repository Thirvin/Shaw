using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIventory : MonoBehaviour
{
    public int max_weight,now_weight;
    public Item[] equiments = new Item[6];
    public Item weapon;
    public List<Item> bag = new List<Item>();
    public Item[] props = new Item[5];

    public void pickup(Item item)
    {
        if(item.weight + now_weight <= max_weight)
        {
            bag.Add(item);
            now_weight += item.weight;
        }
        else
        {
            //show player that bag is full
        }
    }
    public void equip_armor(Item armor)
    {
        //check if able to equip

        //equip the armor

        equiments[armor.wearable] = armor;
    }
    public void switch_weapon(Item weapon)
    {
        //check if able to equip

        //change weapon id
    }
}
