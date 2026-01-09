using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
==================================================
 PlayerMovement.cs
==================================================
Manages the player's movement
==================================================
*/
public class PlayerMovement : MonoBehaviour
{
    [Range(1.0f, 6.0f)] // <--- shows up as a slider in the inspector
    [SerializeField] private float moveSpeed = 6f; // player's move speed

    private float verticalInput; // the player's vertical input (W, S keys)
    private float horizontalInput; // the player's horizontal input (A, D keys)

    private Rigidbody rb; // a reference to the player's rigid body

    // Start is called before the first frame update
    void Start()
    {
        // get the player's rigidbody 
        rb = GetComponent<Rigidbody>();

        // if the rigidbody couldn't be found, make sure one is added
        if (rb == null)
        {
            gameObject.AddComponent<Rigidbody>();
            rb = GetComponent<Rigidbody>();
            Debug.Log("[RIGIDBODY ADDED TO PLAYER]");
        }

        rb.freezeRotation = true; // ensure rotation is frozen to avoid player tipping over
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
    }

    void FixedUpdate()
    {
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput; // calculate the player's movement direction based on their horizontal (A, D) and vertical (W, S) input
        
        // if the player moves diagonally, (i.e. pressing A and W at the same time), the calculated movement vector will be longer than 1, and lead to increased speed
        // normalize the movement direction to ensure the player moves at consistent speed
        if (movementDirection.magnitude > 1f)
        {
            movementDirection = movementDirection.normalized;
        }

        // multiply the movement direction vector by the movement speed in order to move at a faster rate
        movementDirection *= moveSpeed;

        // finally, move the player
        rb.MovePosition(transform.position + movementDirection * Time.fixedDeltaTime);
    }

    private void GetPlayerInput()
    {
        verticalInput = Input.GetAxis("Vertical"); // get the player's vertical input (W, S)
        horizontalInput = Input.GetAxis("Horizontal"); // get the player's horizontal input (A, D)
    }
}
