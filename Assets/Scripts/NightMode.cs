using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OculusSampleFramework;



public class NightMode : MonoBehaviour
{
    [SerializeField] private Material[] skyboxMaterials; // Array of skybox materials to cycle through
    [SerializeField] private UnityEvent[] events; // Unity events to trigger when changing skybox

    private int currentIndex = 0; // Index of the current skybox material
    private bool isGrabbing =false; // Flag to track if the object is being grabbed

    private void Update()
    {
        if (isGrabbing ) // Check if the primary hand trigger is pressed while grabbing
        {
            ChangeSkybox();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hand")&& isGrabbing==false) // Assuming your Oculus Quest Controller's collider is tagged as "Hand"
        {
            isGrabbing = true; Debug.Log('1');// Set the flag to true when the controller collider enters the object's collider
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hand")&& isGrabbing==true)
        {
            isGrabbing = false; Debug.Log('0');// Reset the flag to false when the controller collider exits the object's collider
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