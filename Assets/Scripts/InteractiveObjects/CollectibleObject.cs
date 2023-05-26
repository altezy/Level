using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : InteractiveObject
{
    [SerializeField] private List<string> items;
    
    protected override bool TryToInteract(PlayerController player)
    {
        var allAdded = true;
        foreach (var item in items)
        {
            if (!player.Inventory.AddItem(item))
            {
                allAdded = false;
            }
        }
        return allAdded;
    }
}