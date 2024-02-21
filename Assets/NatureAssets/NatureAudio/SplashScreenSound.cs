using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightModeController : MonoBehaviour
{
    public Material daySkybox;
    public Material nightSkybox;
    public GameObject owlObject;

    private bool nightModeActivated = false;

    void Start()
    {
        // Ensure the owl object is assigned
        if (owlObject == null)
        {
            Debug.LogError("Owl object is not assigned!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the owl object
        if (collision.gameObject == owlObject)
        {
            ToggleNightMode();
        }
    }

    void ToggleNightMode()
    {
        nightModeActivated = !nightModeActivated;

        // Change the skybox material based on the night mode status
        RenderSettings.skybox = nightModeActivated ? nightSkybox : daySkybox;
    }
}
