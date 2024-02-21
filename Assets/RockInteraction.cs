using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RockInteraction : MonoBehaviour
{
    public GameObject planeToGlow;
    private Material planeMaterial;
    private bool isHeld = false;

    private void Start()
    {
        // Assuming the plane_to_glow object has a MeshRenderer component and the glowing material is assigned in the Unity Editor
        planeMaterial = planeToGlow.GetComponent<MeshRenderer>().material;

        // Disable the emission property initially
        planeMaterial.DisableKeyword("_EMISSION");
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (!isHeld)
        {
            isHeld = true;
            // Activate the plane's emission when a rock is picked up
            planeMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (isHeld)
        {
            isHeld = false;
            // Deactivate the plane's emission when a rock is released
            planeMaterial.DisableKeyword("_EMISSION");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AudioTrigger"))
        {
            // Assign the interaction events when a rock with "AudioTrigger" tag enters the trigger area
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnGrab);
                grabInteractable.selectExited.AddListener(OnRelease);
            }
        }
    }
}
