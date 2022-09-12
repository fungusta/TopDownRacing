using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Determines player movement data
 */
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundMask; //For what object tags should the ground check for


    public bool isGrounded;

    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        groundCheck = GameObject.FindWithTag("Ground Check").transform;
    }   

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //If W key is pressed, Input.GetAxis("Vertical") will be equals to 1, for horizontal, it is S key

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        //Will check if a sphere of radius:groundCheckRadius comes into contact with any gameObjects of type groundMask

        Vector3 moveAmount = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * moveAmount);
        //multiply by deltaTime to make it frame Independent

        if (!isGrounded)
        {
            velocity.y += gravity * Mathf.Pow(Time.deltaTime, 2); //Affected by gravity

            controller.Move(velocity);
        } else
        {
            velocity.y = -2f; //Not affected
        }
    }
}
