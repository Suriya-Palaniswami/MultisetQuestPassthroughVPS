using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Time before the bullet is automatically destroyed if it doesn't hit anything (seconds)")]
    public float lifeTime = 10f;

    private void Start()
    {
        // Ensure the bullet doesn't live forever even if it somehow never collides with anything.
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet as soon as it collides with any object.
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Support trigger colliders as well.
        Destroy(gameObject);
    }
}
