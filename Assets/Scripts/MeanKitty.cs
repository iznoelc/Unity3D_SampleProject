using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
==================================================
 MeanKitty.cs
==================================================
Handles behavior of the mean cat.
==================================================
*/
public class MeanKitty : Cat
{
    // player should be able to interact with the nice cat at the start of the game
    void Start()
    {
        canInteract = true;
    }

    /*
    * ==============================
    * Control what happens when the player interacts with the mean cat, and only if the cat is interactable.
    * ==============================
    */
    public override void InteractAction()
    {
        if (canInteract)
        {
            Debug.Log("Mean kitty interact action");
            audioManager.PlayMeanSound(); // play the mean kitty sound
            player.SetReputation(player.GetReputation() - Random.Range(0, maxReputationEffect + 1)); // decrease the players repuation by a random amount between 0 and the cat's maxReputationEffect
            canInteract = false; // make the cat non interactable


            Invoke(nameof(ResetInteractCooldown), 0.5f); // reset the cat's interactability after a short cooldown
        }
    }
}

