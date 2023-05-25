using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] private bool destroyAfterInteraction;
    private PlayerController player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            GameObject.Find("InteractMessage").SetActive(true);
            this.player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            GameObject.Find("InteractMessage").SetActive(false);
            this.player = null;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && player)
        {
            if (TryToInteract(player))
            {
                GameObject.Find("InteractMessage").SetActive(false);
                if (destroyAfterInteraction)
                {
                    Destroy(gameObject);
                }
                enabled = false;
            }
        }
    }

    protected abstract bool TryToInteract(PlayerController player);
}
