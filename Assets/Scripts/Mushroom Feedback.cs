using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomFeedback : MonoBehaviour
{
    public AudioClip hapticAudioClip; // Audio clip for haptic feedback
    public AudioClip collisionAudioClip; // Audio clip for collision feedback

    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger is the player or another object you want to trigger the effect
        if (other.CompareTag("hand")) // Change "Player" to the appropriate tag
        {

            // Trigger haptic feedback when the player's hand collides with the flower
            OVRHapticsClip hapticsClip = new OVRHapticsClip(hapticAudioClip);
            OVRHaptics.RightChannel.Mix(hapticsClip);

            // Play collision audio feedback
            audioSource.PlayOneShot(collisionAudioClip);

        }
    }

}
