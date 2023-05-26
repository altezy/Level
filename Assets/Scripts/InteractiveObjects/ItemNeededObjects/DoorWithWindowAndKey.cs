using UnityEngine;

public class DoorWithWindowAndKey : ContainerObject
{
    [SerializeField] private GameObject key;

    protected override void Interact(PlayerController player)
    {
        base.Interact(player);
        Destroy(key);
    }
}