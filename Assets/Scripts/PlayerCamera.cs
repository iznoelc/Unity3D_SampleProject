using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
==================================================
 PlayerCamera.cs
==================================================
Handles camera movement based on player mouse input
==================================================
*/
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float xSensitivity; // x sensitivity of the camera
    [SerializeField] private float ySensitivity; // y sensitivity of the camera

    [SerializeField] private Transform orientation; // the player's orientation
    [SerializeField] private Transform player; // a reference to the player's transform

    private float xRotation; // the player's x rotation
    private float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        // make sure the cursor is locked to the middle of the screen and invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // get the mouse input to control the camera
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySensitivity;

        // get x and y rotation that the camera should be looking
        yRotation += mouseX; // horizontal mouse movement rotates the camera around the y axis
        xRotation -= mouseY; // vertical mouse movement rotates the camera around the x axis

        xRotation = Mathf.Clamp(xRotation, -90, 90); // ensures player cant look more than 90 degrees up or down

        // rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        player.rotation = orientation.rotation; // this makes sure the player's physical body matches where they are looking/the camera's rotation. doesn't matter so much, though, when the player is just a capsule. 
    }
}
