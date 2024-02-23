using System.Collections;
using UnityEngine;
using OculusSampleFramework; // Import the Oculus Integration namespace

public class GlowingFlowerController : MonoBehaviour
{
    public ParticleSystem glowingPollen; // Reference to the Glowing Pollen particle system
    public AudioClip hapticAudioClip; // Audio clip for haptic feedback
    float delay;


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

            // Trigger haptic feedback when the player's hand collides with the flower
            OVRHapticsClip hapticsClip = new OVRHapticsClip(hapticAudioClip);
            OVRHaptics.RightChannel.Mix(hapticsClip);

    

            // Start a coroutine to stop the particle system after a delay
            StartCoroutine(StopParticleAfterDelay(delay));
        }
    }

    // Coroutine to stop the particle system after a delay
    IEnumerator StopParticleAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(2f);

        // Stop the Glowing Pollen particle system
        glowingPollen.Stop();
    }
}
