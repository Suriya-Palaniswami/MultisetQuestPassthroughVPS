using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiateAndProjectile : MonoBehaviour
{
    // Prefab of the bullet to instantiate.
    public GameObject bulletPrefab;

    // Points from which bullets will be spawned. Assign these in the Inspector.
    public List<Transform> spawnPoints = new List<Transform>();

    // The target the bullets will be shot at (e.g., the player's rig or camera).
    public Transform target;

    // How fast the bullets travel.
    public float bulletSpeed = 10f;

    // Time between each bullet spawn.
    public float spawnInterval = 1f;

    private void Start()
    {
        // Fallback if the user forgets to set the target: use the main camera.
        if (target == null && Camera.main != null)
        {
            target = Camera.main.transform;
        }

        if (bulletPrefab == null || spawnPoints.Count == 0 || target == null)
        {
            Debug.LogError("InstantiateAndProjectile: Please assign a bulletPrefab, at least one spawn point, and a target transform.");
            enabled = false;
            return;
        }

        // Begin spawning bullets.
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        // Repeatedly spawn bullets at the given interval.
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBullet()
    {
        // Select a random spawn point.
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        // Instantiate the bullet.
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

        // Orient the bullet to face the target.
        Vector3 direction = (target.position - spawnPoint.position).normalized;
        bullet.transform.forward = direction;

        // Push the bullet towards the target if it has a Rigidbody.
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
