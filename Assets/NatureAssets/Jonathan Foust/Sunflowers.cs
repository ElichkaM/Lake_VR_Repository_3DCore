using UnityEngine;

public class SunflowerController : MonoBehaviour
{
    // The name of the sunflower to track
    public string sunflowerName = "Sunflower";

    // Update is called once per frame
    void Update()
    {
        // Get the position of the player's head
        Vector3 headPosition = Camera.main.transform.position;

        // Find all sunflowers with the specified name
        GameObject[] sunflowers = GameObject.FindGameObjectsWithTag("Sunflower");

        foreach (GameObject sunflower in sunflowers)
        {
            // Check if the sunflower's name contains the specified name
            if (sunflower.name.Contains(sunflowerName))
            {
                // Rotate the sunflower to face the player's head position
                sunflower.transform.LookAt(headPosition);
            }
        }
    }
}
