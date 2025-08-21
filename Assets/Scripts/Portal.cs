using UnityEngine;

/// <summary>
/// Attach this script to each portal GameObject. Make sure the portal has a Collider
/// marked as a Trigger. Assign the matching portal in the Inspector.
/// </summary>
[RequireComponent(typeof(Collider))]
public class Portal : MonoBehaviour
{
    [Tooltip("Reference to the partner portal (exit portal).")]
    public Portal pairedPortal;

    [Tooltip("Multiplier applied to the object's speed as it exits the portal.")]
    public float exitSpeedMultiplier = 1.1f;

    [Tooltip("Optional transform used as the precise spawn position + forward when objects EXIT from this portal.  Leave null to use this GameObject's transform.")]
    public Transform exitSpawnPoint;

    // Offset forward from the exit portal where the object is spawned to avoid immediate re-collision
    private const float exitOffset = 1f;

    private void Awake()
    {
        // Ensure our collider is set to trigger so objects can pass through
        Collider col = GetComponent<Collider>();
        if (!col.isTrigger)
        {
            Debug.LogWarning($"Portal '{name}' collider was not a trigger. Setting it automatically.");
            col.isTrigger = true;
        }

        if (pairedPortal == null)
        {
            Debug.LogError($"Portal '{name}' does not have a paired portal assigned!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Need a rigidbody to apply physics after teleport
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null || pairedPortal == null) return;

        // Retrieve / add traveller component to manage cooldown
        PortalTraveller traveller = other.GetComponent<PortalTraveller>();
        if (traveller == null)
        {
            traveller = other.gameObject.AddComponent<PortalTraveller>();
        }

        // If we just exited this same portal, ignore to prevent immediate loop
        if (traveller.IsCoolingDown(this)) return;

        // Record teleport through this portal so that traveller can't immediately return
        traveller.TeleportedThrough(this);

        // Cache existing speed to preserve momentum
        float incomingSpeed = rb.linearVelocity.magnitude;

        // Calculate spawn position & velocity based on exit portal orientation
        Transform outTransform = pairedPortal.exitSpawnPoint != null ? pairedPortal.exitSpawnPoint : pairedPortal.transform;

        Vector3 exitDir = outTransform.forward.normalized;
        Vector3 spawnPos = outTransform.position + exitDir * exitOffset;

        // Teleport the object (use MovePosition to respect physics engine)
        rb.position = spawnPos;
        rb.linearVelocity = exitDir * incomingSpeed * exitSpeedMultiplier;
    }

    private void OnDrawGizmos()
    {
        // Draw a simple arrow to indicate exit direction in the editor
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
