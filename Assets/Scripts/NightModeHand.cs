using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NightModeHand : MonoBehaviour
{
    [SerializeField] private Material[] skyboxMaterials; // Array of skybox materials to cycle through
    [SerializeField] private UnityEvent[] events; // Unity events to trigger when changing skybox

    private int currentIndex = 0; // Index of the current skybox material

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")) // Assuming your hand collider is tagged as "Hand"
        {
            ChangeSkybox();
        }
    }

    public void ChangeSkybox()
    {
        currentIndex = (currentIndex + 1) % skyboxMaterials.Length; // Cycle to the next skybox material
        RenderSettings.skybox = skyboxMaterials[currentIndex]; // Set the new skybox material

        if (events.Length > currentIndex && events[currentIndex] != null)
        {
            events[currentIndex].Invoke(); // Invoke the corresponding Unity event
        }
    }
}
