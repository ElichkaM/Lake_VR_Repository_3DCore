using UnityEngine;

public class Sound_collider_trial_grid
    : MonoBehaviour
{
    public AudioClip audioClip; // Assign your audio clip in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Audio Trigger"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}