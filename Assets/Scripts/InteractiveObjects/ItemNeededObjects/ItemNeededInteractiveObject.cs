using UnityEngine;

public class ItemNeededInteractiveObject : InteractiveObject
{
    [SerializeField] protected string neededItem;
    [SerializeField] protected string cannotInteractMessage;
    
    protected override bool TryToInteract(PlayerController player)
    {
        if (neededItem == "" || player.Inventory.ContainsItem(neededItem))
        {
            MessageView.HideMessage();
            player.Inventory.RemoveItem(neededItem);
            Interact(player);
            return true;
        }
        MessageView.ShowMessage(cannotInteractMessage);
        return false;
    }

    protected virtual void Interact(PlayerController player)
    {
    }
}