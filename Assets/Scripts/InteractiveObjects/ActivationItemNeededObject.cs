using System.Collections.Generic;
using UnityEngine;

public abstract class ActivationItemNeededObject : InteractiveObject
{
    [SerializeField] protected List<string> itemsNeededForActivation;

    protected override bool CanActivate(PlayerController player)
    {
        foreach (var item in itemsNeededForActivation)
        {
            if (!player.Inventory.ContainsItem(item))
            {
                return false;
            }
        }
        return true;
    }
}