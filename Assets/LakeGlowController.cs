using UnityEngine;

public class LakeGlowController : MonoBehaviour
{
    public GameObject glowingPlane;
    private Material planeMaterial;
    private bool isColliding = false;

    private void Start()
    {
        // Assuming the glowingPlane object has a MeshRenderer component and the glowing material is assigned in the Unity Editor
        planeMaterial = glowingPlane.GetComponent<MeshRenderer>().material;

        // Disable the emission property initially
        planeMaterial.DisableKeyword("_EMISSION");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Audio Trigger"))
        {
            // Activate the plane's emission when collider_for_lake_glow collides with a game object tagged "Audio Trigger"
            isColliding = true;
            planeMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Audio Trigger"))
        {
            // Deactivate the plane's emission when collider_for_lake_glow and game object tagged "Audio Trigger" are separated
            isColliding = false;
            planeMaterial.DisableKeyword("_EMISSION");
        }
    }
}
