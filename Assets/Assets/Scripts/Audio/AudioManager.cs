using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource Sound;

    [Header("Audio Effects")]
    public AudioClip Coin;

    // Method of playing effect, accepts any effect from cached
    public void PlaySound(AudioClip sound)
    {
        Sound.clip = sound;
        Sound.Play();
    }
}
