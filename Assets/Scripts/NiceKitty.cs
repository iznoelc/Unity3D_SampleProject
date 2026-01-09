using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
==================================================
 NiceKitty.cs
==================================================
Handles behavior of the nice cat.
==================================================
*/
public class NiceKitty : Cat
{
    // player should be able to interact with the nice cat at the start of the game
    void Start()
    {
        canInteract = true;
    }

    /*
    * ==============================
    * Control what happens when the player interacts with the nice cat, and only if the cat is interactable.
    * ==============================
    */
    public override void InteractAction()
    {
        if (canInteract)
        {
            Debug.Log("Nice kitty interact action");
            audioManager.PlayNiceSound(); // play the nice kitty sound
            player.SetReputation(player.GetReputation() + Random.Range(0, maxReputationEffect + 1)); // increase the players repuation by a random amount between 0 and the maxRepuationEffect
            canInteract = false; // make cat non interactable


            Invoke(nameof(ResetInteractCooldown), 0.5f); // reset interactability after a short cooldown
        }
    }
}

