using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{
    [SerializeField] AudioClip footstepsSFX;
    Movement playerMovement;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<Movement>();
    }
    void Update()
    {

        if (GameManager.Instance.IsPlaying)
        {

            //Check if running
            if (playerMovement.IsRunning && !audioSource.isPlaying)
            {
                GetComponent<AudioSource>().PlayOneShot(footstepsSFX);
            }
        }



    }
}
