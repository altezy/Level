using System.Collections.Generic;
using UnityEngine;

public class Carpet : InteractiveObject
{
    [SerializeField] private List<InteractiveObject> objectsUnderCarpet;

    protected override bool TryToInteract(PlayerController player)
    {
        foreach (var interactiveObject in objectsUnderCarpet)
        {
            interactiveObject.enabled = true;
        }
        return true;
    }
}