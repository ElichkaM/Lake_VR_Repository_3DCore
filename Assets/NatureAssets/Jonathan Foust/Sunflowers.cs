using UnityEngine;
using System.Collections;
using OculusSampleFramework;

public class SunflowerController : MonoBehaviour
{
    // The names of the sunflowers to track
    public string[] sunflowerNames = { "Sunflower 1", "Sunflower 1 (3)", "Sunflower 1 (7)" };

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(RotateSunflowersWithDelay());
    }

    IEnumerator RotateSunflowersWithDelay()
    {
        while (true)
        {
            // Get the position of the player's head
            Vector3 headPosition = Camera.main.transform.position;

            // Find all sunflowers with the specified names
            GameObject[] sunflowers = GameObject.FindGameObjectsWithTag("Sunflower");

            foreach (GameObject sunflower in sunflowers)
            {
                // Check if the sunflower's name matches any of the specified names
                foreach (string name in sunflowerNames)
                {
                    if (sunflower.name.Contains(name))
                    {
                        // Rotate the sunflower to face the player's head position
                        sunflower.transform.LookAt(headPosition);
                    }
                }
            }

            yield return new WaitForSeconds(1f); // 1 second delay before rotating again
        }
    }
}
