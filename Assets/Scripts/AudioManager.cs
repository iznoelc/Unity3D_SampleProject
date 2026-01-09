using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
==================================================
 AudioManager.cs
==================================================
Handles playing audio in the game.
==================================================
*/
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSrc; // the player's audio manager to handle action audio (walking)

    [SerializeField] private AudioClip meanMeow; // sfx for walking
    [SerializeField] private AudioClip niceMeow; // sfx for dribbling

    /*
    * ==============================
    * Plays the mean cat sound (hissing)
    * ==============================
    */
    public void PlayMeanSound()
    {
        audioSrc.PlayOneShot(meanMeow, 0.1f);
    }

    /*
    * ==============================
    * Plays the nice cat sound (a nice sweet meow)
    * ==============================
    */
    public void PlayNiceSound()
    {
        audioSrc.PlayOneShot(niceMeow, 0.1f);
    }
}
