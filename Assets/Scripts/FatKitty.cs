using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;

/*
==================================================
 FatKitty.cs
==================================================
Handles behavior of the fat cat.
==================================================
*/
public class FatKitty : Cat
{
    [SerializeField] private float spinSpeed = 5.0f; // how fast the cat should spin
    private bool isSpinning; // whether or not the cat should be spinning

    // fat cat should not be spinning at start and should be interactable
    void Start()
    {
        isSpinning = false;
        canInteract = true;
    }

    // if isSpinning is ever updated to true, the cat should start spinning
    void Update()
    {
        if (isSpinning)
        { 
            Spin();
        }
    }

    /*
    * ==============================
    * Logic to spin the cat
    * ==============================
    */
    private void Spin()
    {
        Debug.Log("Spinning");
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    /*
    * ==============================
    * Logic to stop spinning the cat and reset interaction
    * ==============================
    */
    private void StopSpinning()
    {
        Debug.Log("CALLING STOPSPINNING()");
        isSpinning = false;
        ResetInteractCooldown();
    }

    /*
    * ==============================
    * Control what happens when the player interacts with the fat cat, and only happens if the cat is interactable
    * ==============================
    */
    public override void InteractAction()
    {
        if (canInteract)
        {
            Debug.Log("Fat kitty interact action");
            player.SetReputation(player.GetReputation() - maxReputationEffect); // decrease the reputation of the player by a fixed amount
            isSpinning = true; // make the cat start spinning
            canInteract = false; // make the cat non-interactable 
            audioManager.PlayMeanSound(); // play the mean cat sound

            Invoke(nameof(StopSpinning), 2.0f); // reset the cat's spin and interaction after a short cooldown
        }
    }
}
