using UnityEngine;

public class GlowingStone : MonoBehaviour
{
    private Material material;
    private bool isPickedUp = false;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.EnableKeyword("_EMISSION"); // Enable emission for the material
        material.SetColor("_EmissionColor", Color.white); // Set initial emission color
    }

    void Update()
    {
        if (!isPickedUp && IsPlayerLookingAtStone())
        {
            material.SetColor("_EmissionColor", Color.yellow); // Change emission color to yellow when looked at
        }
        else
        {
            material.SetColor("_EmissionColor", Color.black); // Turn off emission when not looked at
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand")) // Assuming the hand collider is tagged as "PlayerHand"
        {
            isPickedUp = true;
            material.SetColor("_EmissionColor", Color.black); // Turn off emission when picked up
        }
    }

    private bool IsPlayerLookingAtStone()
    {
        // Get the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);

        // Cast a ray from the center of the screen into the scene
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        // Create a RaycastHit variable to store information about the object hit by the ray
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object hit by the ray is the glowing stone
            if (hit.collider.gameObject == gameObject)
            {
                return true; // The player is looking at the stone
            }
        }

        return false; // The player is not looking at the stone
    }
}