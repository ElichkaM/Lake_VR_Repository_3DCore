using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RockInteractionTrigger : MonoBehaviour
{
    public GameObject glowingPlane;
    private Material planeMaterial;

    private void Start()
    {
        // Assuming the plane has a MeshRenderer component and the glowing material is assigned in the Unity Editor
        planeMaterial = glowingPlane.GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AudioTrigger"))
        {
            // Start glowing when the rock enters the trigger area
            planeMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AudioTrigger"))
        {
            // Stop glowing when the rock exits the trigger area
            planeMaterial.DisableKeyword("_EMISSION");
        }
    }
}