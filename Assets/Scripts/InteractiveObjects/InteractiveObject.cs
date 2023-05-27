using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    protected enum AfterInteraction
    {
        StayAfterInteraction,
        DisableAfterInteraction,
        DeactivateAfterInteraction,
        DestroyAfterInteraction
    }

    [SerializeField] private Collider trigger;
    [SerializeField] protected AfterInteraction afterInteraction;
    [SerializeField] protected string successfulInteractionMessage;
    [SerializeField] private InteractiveObject nextInteractionSettings;
    [SerializeField] private PlayerController player;
    private MessageView messageView;

    protected MessageView MessageView => messageView;

    private void Start()
    {
        messageView = FindObjectOfType<MessageView>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enabled && other.TryGetComponent<PlayerController>(out var player) && !player.locked && CanActivate(player))
        {
            player.locked = true;
            player.InteractMessage.SetActive(true);
            this.player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (enabled && other.TryGetComponent<PlayerController>(out var player))
        {
            player.locked = false;
            player.InteractMessage.SetActive(false);
            this.player = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player)
        {
            if (TryToInteract(player))
            {
                messageView.ShowMessage(successfulInteractionMessage);
                if (nextInteractionSettings)
                {
                    player.locked = false;
                    nextInteractionSettings.enabled = true;
                }
                switch (afterInteraction)
                {
                    case AfterInteraction.DestroyAfterInteraction:
                        player.locked = false;
                        player.InteractMessage.SetActive(false);
                        Destroy(gameObject);
                        break;
                    case AfterInteraction.DisableAfterInteraction:
                        player.locked = false;
                        player.InteractMessage.SetActive(false);
                        enabled = false;
                        break;
                    case AfterInteraction.DeactivateAfterInteraction:
                        player.locked = false;
                        player.InteractMessage.SetActive(false);
                        gameObject.SetActive(false);
                        break;
                    case AfterInteraction.StayAfterInteraction:
                        break;
                }
            }
        }
    }

    protected abstract bool CanActivate(PlayerController player);
    
    protected abstract bool TryToInteract(PlayerController player);
}
