using UnityEngine;

/// <summary>
/// Spawns a prefab the moment this GameObject collides with something tagged as "Floor".
/// Attach this script to any moving GameObject (e.g., a projectile).
/// </summary>
public class InstantiateOnFloor : MonoBehaviour
{
    [Tooltip("Prefab that will be spawned once this object hits the floor")] 
    public GameObject dartStick;
    public GameObject tennisBall;

    [Tooltip("Tag assigned to objects that are considered 'floor'")]
    public string floorTag = "Floor";

    [Tooltip("Optional offset applied to the spawn position")]
    public Vector3 spawnOffset = Vector3.up * 0.01f;

    public Vector3 spawnPositionDartStick = new Vector3(0, 0, 0);

    public Vector3 spawnPositionTennisBall = new Vector3(0, 0, 0);

    private bool hasSpawned;

    private GameObject prefabToInstantiate;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasSpawned) return;

        // Ensure the collided object is the floor
        if (collision.collider.CompareTag(floorTag))
        {
            // Use the first contact point for accurate placement

            if(collision.collider.CompareTag("DartStick"))
            {
                prefabToInstantiate = dartStick;
            }
            else if(collision.collider.CompareTag("TennisBall"))
            {
                prefabToInstantiate = tennisBall;
            }

            if(prefabToInstantiate == dartStick)
            {
                Vector3 spawnPosition = spawnPositionDartStick;
            }
            else if(prefabToInstantiate == tennisBall)
            {
                Vector3 spawnPosition = spawnPositionTennisBall;

            Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
            hasSpawned = true;
        }
        }
    }
}
