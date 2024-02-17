using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public ParticleSystem splashParticles; // Reference to the ParticleSystem

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the object you want to trigger the particles
        if (collision.gameObject.CompareTag("Audio Trigger") || collision.gameObject.CompareTag("Obstacle"))
        {
            TriggerSplashParticles();
        }
    }

    void TriggerSplashParticles()
    {
        // Check if the ParticleSystem is valid
        if (splashParticles != null)
        {
            // Play the ParticleSystem
            splashParticles.Play();
        }
    }
}
