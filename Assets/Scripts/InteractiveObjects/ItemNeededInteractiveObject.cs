using TMPro;
using UnityEngine;

public class ItemNeededInteractiveObject : InteractiveObject
{
    [SerializeField] private string neededItem;
    [SerializeField] private string cannotInteractMessage;
    [SerializeField] private TextMeshProUGUI cannotInteractWindow;
    
    protected override bool TryToInteract(PlayerController player)
    {
        if (player.Inventory.ContainsItem(neededItem))
        {
            cannotInteractWindow.text = "";
            player.Inventory.RemoveItem(neededItem);
            Interact();
            return true;
        }
        cannotInteractWindow.text = cannotInteractMessage;
        return false;
    }

    protected virtual void Interact()
    {
    }
}