using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemNeededInteractiveObject : ActivationItemNeededObject
{
    [Serializable]
    protected struct NeededItem
    {
        [SerializeField] private string itemName;
        [SerializeField] private bool spendAfterUse;

        public string ItemName => itemName;
        public bool SpendAfterUse => spendAfterUse;
    }
    
    [SerializeField] protected List<NeededItem> neededItems;
    [SerializeField] protected string cannotInteractMessage;
    
    protected override bool TryToInteract(PlayerController player)
    {
        foreach (var item in neededItems)
        {
            Debug.Log(player.Inventory.ContainsItem(item.ItemName));
            if (!player.Inventory.ContainsItem(item.ItemName))
            {
                MessageView.ShowMessage(cannotInteractMessage);
                return false;
            }
        }
        MessageView.HideMessage();
        foreach (var item in neededItems)
        {
            if (item.SpendAfterUse)
            {
                player.Inventory.RemoveItem(item.ItemName);
            }
        }
        Interact(player);
        return true;
        
    }

    protected virtual void Interact(PlayerController player)
    {
    }
}