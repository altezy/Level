using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private GameObject interactMessage;
    [SerializeField] private GameObject transportMessage;
    public bool locked;
    
    public PlayerInventory Inventory => inventory;
    public GameObject InteractMessage => interactMessage;
    public GameObject TransportMessage => transportMessage;
}
