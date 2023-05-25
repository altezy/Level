using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
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
            return true;
        }
        return false;
    }

    public void RemoveItem(string item)
    {
        items.Remove(item);
    }

    public bool ContainsItem(string name)
    {
        return items.Contains(name);
    }
}