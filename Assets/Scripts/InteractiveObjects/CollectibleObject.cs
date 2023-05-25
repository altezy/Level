using UnityEngine;

public class CollectibleObject : InteractiveObject
{
    [SerializeField] private string item;
    
    protected override bool TryToInteract(PlayerController player)
    {
        return player.Inventory.AddItem(item);
    }
}