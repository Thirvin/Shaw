using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject equipmentsUI;
    public GameObject propsUI;
    public GameObject bagContentUI;

    public List<GameObject> euipmentBoxes;
    public List<GameObject> propBoxes;
    void Start()
    {
        InventoryManager.Instance.bagUI = bagUI;
        InventoryManager.Instance.equipmentsUI = equipmentsUI;
        InventoryManager.Instance.propsUI = propsUI;
        InventoryManager.Instance.bagContentUI = bagContentUI;
        InventoryManager.Instance.equipmentBoxes = euipmentBoxes;
        InventoryManager.Instance.propBoxes = propBoxes;
    }

}
