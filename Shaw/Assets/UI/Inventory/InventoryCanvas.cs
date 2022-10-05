using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject equipmentsUI;
    public GameObject propsUI;
    public GameObject bagContentUI;
    void Start()
    {
        InventoryManager.Instance.bagUI = bagUI;
        InventoryManager.Instance.equipmentsUI = equipmentsUI;
        InventoryManager.Instance.propsUI = propsUI;
        InventoryManager.Instance.bagContentUI = bagContentUI;
    }

}
