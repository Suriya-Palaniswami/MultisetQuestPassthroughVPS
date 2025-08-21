using UnityEngine;

public class PortalTraveller : MonoBehaviour
{
    private Portal lastPortal;              // The portal this object most recently exited
    private float cooldownTimer = 0f;       // Tracks time since exiting last portal

    [Tooltip("How long (in seconds) the object must wait before it can be teleported again.")]
    [SerializeField] private float cooldownDuration = 0.2f;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Returns true if this traveller is still on cooldown for the given portal.
    /// </summary>
    public bool IsCoolingDown(Portal portal)
    {
        return lastPortal == portal && cooldownTimer < cooldownDuration;
    }

    /// <summary>
    /// Call when the traveller is teleported through a portal.
    /// </summary>
    public void TeleportedThrough(Portal portal)
    {
        lastPortal = portal;
        cooldownTimer = 0f;
    }

    private void Update()
    {
        if (lastPortal != null)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownDuration)
            {
                // Cooldown finished; ready to be teleported again
                lastPortal = null;
                cooldownTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
