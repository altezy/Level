using UnityEngine;

public class Shelf : ItemNeededInteractiveObject
{
    [SerializeField] private GameObject objectOnShelf;
    [SerializeField] private Vector3 takenObjectCoordinates;

    protected override void Interact(PlayerController player)
    {
        base.Interact(player);
        objectOnShelf.transform.position = takenObjectCoordinates;
        if (objectOnShelf.TryGetComponent<InteractiveObject>(out var interactiveObject))
        {
            interactiveObject.enabled = true;
        }
    }
}