using UnityEngine;

/// <summary>
/// Toggles (activates/deactivates) a set of objects when other objects enter or exit this GameObject's trigger collider.
/// Attach this script to a GameObject that has a Collider set to "Is Trigger".
/// </summary>
public class TriggerActivator : MonoBehaviour
{
    [Tooltip("Objects that will be activated/deactivated when something enters/exits this trigger")]
    [SerializeField] private GameObject[] objectsToToggle;

    [Tooltip("Optional: Only toggle when objects with this tag enter/exit. Leave empty to accept any object.")]
    [SerializeField] private string requiredTag = "";

    private void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(requiredTag) || other.CompareTag(requiredTag))
        {
            foreach (var obj in objectsToToggle)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (string.IsNullOrEmpty(requiredTag) || other.CompareTag(requiredTag))
        {
            foreach (var obj in objectsToToggle)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

#if UNITY_EDITOR
    private void Reset()
    {
        // Ensure the attached collider is set as a trigger for convenience
        var col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }
#endif
}



