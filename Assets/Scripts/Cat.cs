using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
==================================================
 Cat.cs
==================================================
Abstract class to handle common functionality among all cats.
==================================================
*/
public abstract class Cat : MonoBehaviour
{
    protected PlayerController player; // a reference to the player, found via code instead of the inspector because this is an abstract class
    protected AudioManager audioManager; // a reference to the audio manager, found via code for same reasons as above

    protected bool canInteract; // a variable to determine whether the cat can be interacted with

    [SerializeField] protected int maxReputationEffect; // the effect interacting with a cat will have on the player's "repuation" (health)


    /*
    * ==============================
    * Finds the player and audio manager on Awake. Prints a debug error if they cannot be found.
    * ==============================
    */
    public void Awake()
    {
        if (player == null)
        {
            player = PlayerController.FindFirstObjectByType<PlayerController>();
        }

        if (audioManager == null)
        {
            audioManager = AudioManager.FindFirstObjectByType<AudioManager>();
        }

        if (player == null) Debug.LogError("No PlayerController object found");
        if (audioManager == null) Debug.LogError("No AudioManager object found");
    }

    /*
    * ==============================
    * Resets a cat's interaction cooldown.
    * ==============================
    */
    protected void ResetInteractCooldown()
    {
        canInteract = true;
    }

    /*
    * ==============================
    * What should happen when the player interacts with a cat; should be implemented by subclasses.
    * ==============================
    */
    public abstract void InteractAction();
}

