using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIventory : MonoBehaviour
{
    public int max_weight;
    public Item[] equiments = new Item[6];
    public Item weapon;
    public List<Item> bag = new List<Item>();
    public Item[] props = new Item[5];

}
