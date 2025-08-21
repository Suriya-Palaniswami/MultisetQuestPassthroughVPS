using UnityEngine;

/// <summary>
/// Attach this script to every dart GameObject. When the tip collider collides with a
/// dartboard (tagged "Dartboard"), the dart freezes and sticks at the hit position.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class DartStick : MonoBehaviour
{
    [Tooltip("Tag assigned to the dartboard collider(s)")]
    [SerializeField] private string dartboardTag = "Dartboard";

    [SerializeField] private AudioSource audioSource;

    private Rigidbody _rb;
    private bool _isStuck;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isStuck) return;
        if (!collision.collider.CompareTag(dartboardTag)) return;

        ContactPoint contact = collision.contacts[0];
        StickToBoard(contact);
        PlayAudio();
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }

    private void StickToBoard(ContactPoint contact)
    {
        _isStuck = true;

        // Freeze the rigidbody so the dart no longer simulates physics
        _rb.isKinematic = true;
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;

        // Place the dart tip exactly where the contact happened
        transform.position = contact.point;

        // Orient the dart so its forward (+Z) points into the board
        transform.rotation = Quaternion.LookRotation(-contact.normal, Vector3.up);

        // Parent to the board so it moves with it
        transform.SetParent(contact.otherCollider.transform, true);
    }

    /// <summary>
    /// Call this when the dart is grabbed again to unstick it and resume physics.
    /// </summary>
    public void Unstick()
    {
        if (!_isStuck) return;

        _isStuck = false;
        transform.SetParent(null, true);
        _rb.isKinematic = false;
    }
}
