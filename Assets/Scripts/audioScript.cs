using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private bool isPlaying = false;

    public void playAudio()
    {
        if (!isPlaying)
        {
            _audioSource.Play();
            isPlaying = true;
        }       
    }
}