using MultiSet;
using UnityEngine;
public class ContinuousLocalization : MonoBehaviour
{

    [SerializeField] private SingleFrameLocalizationManager m_localizationManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TriggerLocalization();
    }

    private void TriggerLocalization()
    {
        if (m_localizationManager != null)
        {
            m_localizationManager.LocalizeFrame();
        }
        else
        {
            Debug.LogError("Cannot trigger localization - LocalizationManager is null!");
        }
    }
}
