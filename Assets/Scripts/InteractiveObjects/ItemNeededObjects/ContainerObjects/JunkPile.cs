using UnityEngine;

public class JunkPile : ContainerObject
{
    [SerializeField] private Vector3 lampPosition;
    [SerializeField] private GameObject lampPrefab;

    protected override void Interact(PlayerController player)
    {
        base.Interact(player);
        var lamp = Instantiate(lampPrefab, lampPosition, Quaternion.identity);
        lamp.transform.parent = transform.parent;
    }
}