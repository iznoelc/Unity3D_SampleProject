using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
==================================================
 ReputationTextController.cs
==================================================
Manages the reputation text's properties
==================================================
*/
public class ReputationTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reputationText; // a reference to the actual reputation text
    [SerializeField] private GameObject player; // a reference to the player
    private int currentReputation; // the player's current reputation

    // Start is called before the first frame update
    void Start()
    {
        // sets the reputation text to be "Reputation: " + the player's max reputation, as they should be at full reputation at the start of the game.
        reputationText.text = "Reputation: " + player.GetComponent<PlayerController>().maxReputation;

        // the reputation text's initial color should be green, since it is full.
        reputationText.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        // get the player's current reputation value and store it in currentReputation
        currentReputation = player.GetComponent<PlayerController>().GetReputation();

        // update the reputation accordingly
        UpdateReputation();
    }

    /*
    * ==============================
    * Update's the reputation text based on the player's current reputation value.
    * ==============================
    */
    public void UpdateReputation()
    {
        reputationText.text = "Reputation: " + currentReputation; // update the text
        DetermineColor(); // determine what color it should be
    }

    /*
    * ==============================
    * Determines and sets what color the reputation should be
    * ==============================
    */
    private void DetermineColor()
    {
        if (currentReputation >= 75) // if reputation is above 70, set the text color to green
        {
            Debug.Log("Setting reputation color to green");
            reputationText.color = Color.green;
        } else if (currentReputation < 75 && currentReputation >= 40) // if the reputation is between 74 and 40, set the reputation color to yellow
        {
            Debug.Log("Setting reputation color to yellow");
            reputationText.color = Color.yellow;
        } else // otherwise, reputation will be below 40, set the text color to red
        {
            Debug.Log("Setting reputation color to red");
            reputationText.color = Color.red;
        }
    }
}
