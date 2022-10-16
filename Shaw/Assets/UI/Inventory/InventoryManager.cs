using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("UI")]
    public GameObject inventoryCanvas;

    public GameObject bagUI;
    public GameObject equipmentsUI;
    public GameObject propsUI;
    public GameObject backgroundUI;

    public GameObject bagContentUI;

    public List<GameObject> equipmentBoxes;
    public List<GameObject> equipmentImages;
    public List<GameObject> propBoxes;
    public List<GameObject> propImages;

    public GameObject currentRightClickMenu;

    [Header("UI prefab")]
    public GameObject itemUIPrefab;

    public GameObject rightClickMenuPrefab;
    public GameObject toolTipPrefab;
    public GameObject eqipButtonPrefab;
    public GameObject unequipmentButtonPrefab;
    public GameObject putInPropsButtonPrefab;
    public GameObject takeOutPropsButtonPrefab;
    public GameObject dropButtonPrefab;
    public GameObject equipmentBoxImagePrefab;

    [Header("Scripts")]
    public PlayerIventory playerIventory;
    public UIItem selectedUIItem;
    public Item item;

    public List<UIItem> equipmentUIItems;
    public List<UIItem> propUIItems;

    [Header("Player stats")]
    public int max_weight, now_weight;
    public Item[] equiments = new Item[6];
    public Item weapon;
    public List<Item> bag = new List<Item>();
    public Item[] props = new Item[3];
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool CheckEquipQualification(Item item)
    {
        Player player = PlayerManager.Instance.player;
        if (item.L_INT > player.INT ||
            item.L_STR > player.STR)
            return true;

        return false;
    }

    public void ItemAddMod(Item item)
    {
        Player player = PlayerManager.Instance.player;
        if(item.ATK.value != 0 || item.ATK.magnifiction != 0)
        {
            player.ATK.AddModifier(item.ATK);
        }
        if (item.MAG.value != 0 || item.MAG.magnifiction != 0)
        {
            player.MAG.AddModifier(item.MAG);
        }
        if (item.DEF.value != 0 || item.DEF.magnifiction != 0)
        {
            player.DEF.AddModifier(item.DEF);
        }
        if (item.DEX.value != 0 || item.DEX.magnifiction != 0)
        {
            player.DEX.AddModifier(item.DEX);
        }
        if (item.LUK.value != 0 || item.LUK.magnifiction != 0)
        {
            player.LUK.AddModifier(item.LUK);
        }
        if (item.VIT.value != 0 || item.VIT.magnifiction != 0)
        {
            player.VIT.AddModifier(item.VIT);
        }
        if (item.MAN.value != 0 || item.MAN.magnifiction != 0)
        {
            player.MAN.AddModifier(item.MAN);
        }
    }

    public void ItemRemoveMod(Item item)
    {
        Player player = PlayerManager.Instance.player;
        if (item.ATK.value != 0 || item.ATK.magnifiction != 0)
        {
            player.ATK.RemoveModifier(item.ATK);
        }
        if (item.MAG.value != 0 || item.MAG.magnifiction != 0)
        {
            player.MAG.RemoveModifier(item.MAG);
        }
        if (item.DEF.value != 0 || item.DEF.magnifiction != 0)
        {
            player.DEF.RemoveModifier(item.DEF);
        }
        if (item.DEX.value != 0 || item.DEX.magnifiction != 0)
        {
            player.DEX.RemoveModifier(item.DEX);
        }
        if (item.LUK.value != 0 || item.LUK.magnifiction != 0)
        {
            player.LUK.RemoveModifier(item.LUK);
        }
        if (item.VIT.value != 0 || item.VIT.magnifiction != 0)
        {
            player.VIT.RemoveModifier(item.VIT);
        }
        if (item.MAN.value != 0 || item.MAN.magnifiction != 0)
        {
            player.MAN.RemoveModifier(item.MAN);
        }
    }
}
