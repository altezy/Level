using System.Collections.Generic;
using UnityEngine;

public class ContainerObject : ItemNeededInteractiveObject
{
    [SerializeField] private List<string> items;
    
    protected override void Interact(PlayerController player)
    {
        foreach (var item in items)
        {
            player.Inventory.AddItem(item);
        }
    }
}