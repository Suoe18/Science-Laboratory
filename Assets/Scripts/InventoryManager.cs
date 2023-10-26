using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField] private GameObject[] inventorySlot;
    [SerializeField] private bool[] isFull;

    [SerializeField] private GameObject[] itemLogo;

    void Awake()
    {
        instance = this;
    }
   

    public void AddItem(int itemCode)
    {
        for(int i = 0; i < inventorySlot.Length; i++)
        {
            if(!isFull[i])
            {
                Instantiate(itemLogo[itemCode], inventorySlot[i].transform, false);
                isFull[i] = true;
                break;
            }
        }
    }

    public void RemoveItem(string childTag)
    {
        GameObject childObject = GameObject.FindGameObjectWithTag(childTag);

        if (childObject != null)
        {            
            Destroy(childObject);
        }
    }

}
