using System.Collections;
using UnityEngine;

public class GlowingFlowerController : MonoBehaviour
{
    public ParticleSystem glowingPollen; // Reference to the Glowing Pollen particle system

    void Start()
    {
        // Ensure the particle system is stopped when the game starts
        glowingPollen.Stop();
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger is the player or another object you want to trigger the effect
        if (other.CompareTag("hand")) // Change "Player" to the appropriate tag
        {
            // Start the Glowing Pollen particle system
            glowingPollen.Play();

            // Start a coroutine to stop the particle system after 2 seconds
            StartCoroutine(StopParticleAfterDelay(3f));
        }
    }

    // Coroutine to stop the particle system after a delay
    IEnumerator StopParticleAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Stop the Glowing Pollen particle system
        glowingPollen.Stop();
    }
}
