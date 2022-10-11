using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

/**
 * Determines player movement data
 */
public class PlayerMovement : NetworkBehaviour
{
    public CharacterController controller;

    private float speed = 30f;
    private readonly float gravity = -9.81f;
    private readonly float rotateSpeed = 100f;

    public GameObject[] wheelGameObjectList;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundMask; //For what object tags should the ground check for


    private bool isGrounded;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        wheelGameObjectList = GameObject.FindGameObjectsWithTag("Ground Check");
    }   

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        UseInputsToMovePlayer();
        UseInputsToRotatePlayer();
        CheckIfGrounded();
        UpdateDownwardVelocityWhenGrounded();
    }

    private void UseInputsToRotatePlayer()
    {
        if (Input.GetAxis("Vertical") == 0f) //guard clause, when no forward movement, no rotation
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float rotation = horizontal * rotateSpeed * Time.deltaTime;
        transform.Rotate(0f, rotation, 0f);
    }

    private void UseInputsToMovePlayer()
    {
        float vertical = Input.GetAxis("Vertical");
        //If W key is pressed, Input.GetAxis("Vertical") will be equals to 1, for horizontal, it is S key
        
        Vector3 moveAmount = transform.forward * vertical;
        controller.Move(speed * Time.deltaTime * moveAmount);
        //multiply by deltaTime to make it frame Independent
    }

    private void CheckIfGrounded()
    {
        foreach (GameObject wheelRadius in wheelGameObjectList)
        {
            isGrounded = Physics.CheckSphere(wheelRadius.transform.position, groundCheckRadius, groundMask);
        }
        //Will check if a sphere of radius:groundCheckRadius comes into contact with any gameObjects of type groundMask
    }

    private void UpdateDownwardVelocityWhenGrounded()
    {
        if (!isGrounded)
        {
            velocity.y += gravity * Mathf.Pow(Time.deltaTime, 2); //Affected by gravity

            controller.Move(velocity);
        }
        else
        {
            velocity.y = -2f; //Not affected
        }
    }

    
}
