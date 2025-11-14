using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSoundcontroller : MonoBehaviour
{
    public AudioClip footstepSound; // Assign your footstep sound in the Inspector
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource if one doesn't exist
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = footstepSound; // Assign the clip to the AudioSource
    }

    void Update()
    {
        // Example: Play sound when a specific key is pressed (representing movement)
        if ( Input.GetKeyDown(KeyCode.A) ||
             Input.GetKeyDown(KeyCode.D))
        {
            if (!audioSource.isPlaying) // Prevent overlapping if already playing
            {
                audioSource.Play();
                //audioSource.loop();
            }
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
                 Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            audioSource.Stop(); // Stop playing when movement ceases
        }
    }
}
