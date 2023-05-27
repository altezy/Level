using UnityEngine;

public class TransportPoint : MonoBehaviour
{
    [SerializeField] private TransportPoint correspondingPoint;
    private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            player.TransportMessage.SetActive(true);
            this.player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            player.TransportMessage.SetActive(false);
            this.player = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player)
        {
            player.transform.position = correspondingPoint.transform.position;
            player.transform.rotation = correspondingPoint.transform.rotation;
        }
    }
}