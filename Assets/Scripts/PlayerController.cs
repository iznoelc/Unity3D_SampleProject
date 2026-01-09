using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
==================================================
 PlayerController.cs
==================================================
Manages the player's actions when it comes to interaction with other game objects.
==================================================
*/
public class PlayerController : MonoBehaviour
{
    [SerializeField] public int maxReputation { get; private set; } = 100; // the max "reputation" (health) the player can have
    [SerializeField] private Cat niceKitty; // a reference to the nice kitty's script
    [SerializeField] private Cat meanKitty; // a reference to the mean kitty's script
    [SerializeField] private Cat fatKitty; // a reference to the fat kitty's script

    [HideInInspector] private int currentReputation; // the amount of reputation the player currently has
    private KeyCode interactKey = KeyCode.E; // interaction keybind

    // whether the player is in range of any of the kitties
    private bool inRangeOfMeanKitty;
    private bool inRangeOfNiceKitty;
    private bool inRangeOfFatKitty;

    // Start is called before the first frame update
    void Start()
    {
        // player should have max reputation at the start of the game, and should not be in range of any of the kitties
        currentReputation = maxReputation;
        inRangeOfMeanKitty = false;
        inRangeOfNiceKitty = false;
        inRangeOfFatKitty = false;
    }

    // Update is called once per frame
    void Update()
    {
        // log if the player is in range of any kitties
        Debug.Log("inRangeOfNiceKitty: " + inRangeOfNiceKitty);
        Debug.Log("inRangeOfMeanKitty: " + inRangeOfMeanKitty);
        Debug.Log("inRangeOfFatKitty: " + inRangeOfFatKitty);

        // interact if needed
        CheckInteraction();
    }

    /*
    * ==============================
    * Gets the player's current reputation
    * ==============================
    */
    public int GetReputation()
    {
        return currentReputation;
    }

    /*
    * ==============================
    * Sets the player's current reputation, forcing it to 100 if it goes over or to 0 if it goes under
    * ==============================
    */
    public void SetReputation(int reputation)
    {
        currentReputation = reputation;
        if (currentReputation > 100)
        {
            Debug.Log("Current reputation went over 100, forcing to 100");
            currentReputation = 100;
        }

        if (currentReputation < 0)
        {
            Debug.Log("Current reputation went below 0, forcing to 0");
            currentReputation = 0;
        }
    }

    /*
    * ==============================
    * Handles player interaction with kitties, interacting with them if in range of them
    * ==============================
    */
    private void CheckInteraction()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (inRangeOfMeanKitty)
            {
                Debug.Log("Interacting with mean kitty");
                meanKitty.InteractAction();
            } else if (inRangeOfNiceKitty) 
            {
                Debug.Log("Interacting with nice kitty");
                niceKitty.InteractAction();
            } else if (inRangeOfFatKitty)
            {
                fatKitty.InteractAction();
            } else
            {
                Debug.Log("Not in range of any kitties");
            }
        }
    }

    /*
    * ==============================
    * Updates inRangeOf variables for each kitty if the player enters the interact trigger collider for a certain kitty
    * ==============================
    */
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MeanKitty"))
        {
            Debug.Log("Able to interact with mean kitty");
            inRangeOfMeanKitty = true;
            
        }

        if (other.CompareTag("NiceKitty"))
        {
            Debug.Log("Able to interact with nice kitty");
            inRangeOfNiceKitty = true;
        }

        if (other.CompareTag("FatKitty"))
        {
            Debug.Log("Able to interact with fat kitty");
            inRangeOfFatKitty = true;
        }
    }

    /*
    * ==============================
    * Updates inRangeOf variables for each kitty if player exits their interact trigger collider
    * ==============================
    */
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MeanKitty"))
        {
            inRangeOfMeanKitty = false;
        }

        if (other.CompareTag("NiceKitty"))
        {
            inRangeOfNiceKitty = false;
        }

        if (other.CompareTag("FatKitty"))
        {
            inRangeOfFatKitty = false;
        }
    }
}
