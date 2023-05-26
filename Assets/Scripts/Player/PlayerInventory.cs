using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryView view;
    private List<string> items;

    private void Start()
    {
        items = new List<string>();
    }

    public bool AddItem(string item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            view.AddItem(item);
            return true;
        }
        return false;
    }

    public bool RemoveItem(string item)
    {
        if (items.Remove(item))
        {
            view.RemoveItem(item);
            return true;
        }
        return false;
    }

    public bool ContainsItem(string name)
    {
        return items.Contains(name);
    }
}