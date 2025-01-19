using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    public void PlayButtonSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}