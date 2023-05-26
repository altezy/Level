using UnityEngine;

public class DoorWithWindowAndKey : ItemNeededInteractiveObject
{
    [SerializeField] private GameObject key;
    [SerializeField] private string keyItem;
    [SerializeField] private string secondNeededItem;
    [SerializeField] private string secondCannotInteractMessage;

    protected override void Interact(PlayerController player)
    {
        base.Interact(player);
        if (SuccessfulIInteractionsCount == 0)
        {
            player.Inventory.AddItem(keyItem);
            Destroy(key);
            neededItem = secondNeededItem;
            cannotInteractMessage = secondCannotInteractMessage;
        }
        else
        {
            afterInteraction = AfterInteraction.DestroyAfterInteraction;
        }
    }
}