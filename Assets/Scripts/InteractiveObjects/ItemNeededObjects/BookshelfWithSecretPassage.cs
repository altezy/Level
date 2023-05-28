using UnityEngine;

namespace InteractiveObjects.ItemNeededObjects
{
    public class BookshelfWithSecretPassage : ItemNeededInteractiveObject
    {
        [SerializeField] private Vector3 newLocation;

        protected override void Interact(PlayerController player)
        {
            base.Interact(player);
            transform.position = newLocation;
        }
    }
}