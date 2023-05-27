using UnityEngine;

namespace InteractiveObjects.ItemNeededObjects
{
    public class Hatch : ItemNeededInteractiveObject
    {
        [SerializeField] private GameObject transportPoint;
        
        protected override void Interact(PlayerController player)
        {
            base.Interact(player);
            transportPoint.SetActive(true);
        }
    }
}