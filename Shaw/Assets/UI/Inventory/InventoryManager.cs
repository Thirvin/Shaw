using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    
    [HeaderAttribute("UI")]
    public GameObject inventoryCanvas;

    public GameObject bagUI;
    public GameObject equipmentsUI;
    public GameObject propsUI;

    public GameObject bagContentUI;

    public GameObject currentRightClickMenu;

    [HeaderAttribute("UI prefab")]
    public GameObject itemUIPrefab;

    public GameObject rightClickMenuPrefab;
    public GameObject eqipButtonPrefab;
    public GameObject putInPropsButtonPrefab;
    public GameObject dropButtonPrefab;

    [HeaderAttribute("Scripts")]
    public PlayerIventory playerIventory;
    public UIItem uIItem;
    public Item item;

    [HeaderAttribute("Player stats")]
    public int max_weight, now_weight;
    public Item[] equiments = new Item[6];
    public Item weapon;
    public List<Item> bag = new List<Item>();
    public Item[] props = new Item[3];
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
