using UnityEngine;

public class ItemNeededInteractiveObject : InteractiveObject
{
    [SerializeField] protected string neededItem;
    [SerializeField] protected string cannotInteractMessage;
    
    protected override bool TryToInteract(PlayerController player)
    {
        if (player.Inventory.ContainsItem(neededItem))
        {
            FindObjectOfType<CannotInteractMessage>().HideMessage();
            player.Inventory.RemoveItem(neededItem);
            Interact(player);
            return true;
        }
        FindObjectOfType<CannotInteractMessage>().ShowMessage(cannotInteractMessage);
        return false;
    }

    protected virtual void Interact(PlayerController player)
    {
    }
}