using System.Collections.Generic;
using UnityEngine;

public class ItemNeededInteractiveObject : ActivationItemNeededObject
{
    [SerializeField] protected List<string> neededItems;
    [SerializeField] protected string cannotInteractMessage;
    
    protected override bool TryToInteract(PlayerController player)
    {
        foreach (var item in neededItems)
        {
            if (!player.Inventory.ContainsItem(item))
            {
                MessageView.ShowMessage(cannotInteractMessage);
                return false;
            }
        }
        MessageView.HideMessage();
        foreach (var item in neededItems)
        {
            player.Inventory.RemoveItem(item);
        }
        Interact(player);
        return true;
        
    }

    protected virtual void Interact(PlayerController player)
    {
    }
}