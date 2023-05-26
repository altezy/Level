using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameObject interactMessage;
    
    public PlayerInventory Inventory => inventory;
    public GameObject InteractMessage => interactMessage;
}
