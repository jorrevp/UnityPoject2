using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip musicClip;  // Assign your audio clip in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;  // Set to true if you want the music to loop
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Music clip not assigned!");
        }
    }
}
