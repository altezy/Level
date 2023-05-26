using UnityEngine;

public class DoorWithCodeLock : ItemNeededInteractiveObject
{
    [SerializeField] private GameObject bookshelf;

    protected override void Interact(PlayerController player)
    {
        base.Interact(player);
        bookshelf.SetActive(true);
    }
}