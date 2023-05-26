using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    protected enum AfterInteraction
    {
        StayAfterInteraction,
        DisableAfterInteraction,
        DestroyAfterInteraction
    }
    
    [SerializeField] protected AfterInteraction afterInteraction;
    private PlayerController player;
    private int successfulIInteractionsCount;

    protected int SuccessfulIInteractionsCount => successfulIInteractionsCount;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            player.InteractMessage.SetActive(true);
            this.player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            player.InteractMessage.SetActive(false);
            this.player = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && player)
        {
            if (TryToInteract(player))
            {
                successfulIInteractionsCount++;
                switch (afterInteraction)
                {
                    case AfterInteraction.DestroyAfterInteraction:
                        player.InteractMessage.SetActive(false);
                        Destroy(gameObject);
                        break;
                    case AfterInteraction.DisableAfterInteraction:
                        player.InteractMessage.SetActive(false);
                        enabled = false;
                        break;
                    case AfterInteraction.StayAfterInteraction:
                        break;
                }
            }
        }
    }

    protected abstract bool TryToInteract(PlayerController player);
}
