using UnityEngine;

public class sound_collider_grid_f_v1 : MonoBehaviour
{
    public AudioClip audioClip; // Assign your audio clip in the Unity Editor
    private AudioSource audioSource;

    private bool isColliding = false;

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
            if (!isColliding)
            {
                audioSource.Play();
                isColliding = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Audio Trigger"))
        {
            isColliding = false;
            audioSource.Stop();
        }
    }
}
