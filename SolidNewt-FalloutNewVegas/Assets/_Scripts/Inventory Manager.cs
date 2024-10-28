using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> itemlist;

    public void AddToInvent(string itemName)
    {
        string item = itemName;
        itemlist.Add(item);
    }

    public void RemoveFromInvent(string itemName)
    {
        string item = itemName;
        itemlist.Remove(item);
    }

    public List<string> GetInventory()
    {
        return itemlist;
    }
}
