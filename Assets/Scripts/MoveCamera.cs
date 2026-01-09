using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
==================================================
 MoveCamera.cs
==================================================
Moves the camera according to the position on the player
==================================================
*/
public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraPos; // should be an empty game object on the player around eye-level, where the camera should be placed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position; // ensure *actual* camera is following the desired camera position
    }
}
