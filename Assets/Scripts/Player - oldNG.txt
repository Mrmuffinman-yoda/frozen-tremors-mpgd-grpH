using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Define in program variables
    private bool isJumping = false;
    private bool isMovingRight = false; //D
    private bool isMovingLeft = false; //A
    private bool isMovingForwards = false; //W
    private bool isMovingBack = false; //S
    private bool isGrounded = false; //Is the player on the ground? Prevents double jumping
    private Rigidbody playerRB;

    //Define inspector variables
    [SerializeField] private Transform playerGroundedTransform; //depracated
    [SerializeField] private int movementMultiplier=1;
    [SerializeField] private int jumpMultipler = 4;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }//test

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        } if (Input.GetKey(KeyCode.W))
        {
            isMovingForwards = true;
        } if (Input.GetKey(KeyCode.S))
        {
            isMovingBack = true;
        } if (Input.GetKey(KeyCode.A))
        {
            isMovingLeft = true;
        } if (Input.GetKey(KeyCode.D))
        {
            isMovingRight = true;
        }
    }

    //Update 100 times p/sec regardless of FPS
    private void FixedUpdate()
    {
        
        if (isJumping && isGrounded)
        {
            //Debug.Log("Keyboard - Spacebar pressed!.. ");
            playerRB.AddForce(Vector3.up * jumpMultipler, ForceMode.Impulse);
            isJumping = false;
        }
        if (isMovingForwards)
        {
            playerRB.velocity=new Vector3(playerRB.velocity.x,playerRB.velocity.y,1*movementMultiplier);
            isMovingForwards = false;
        }
        if (isMovingBack)
        {
            playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y,-1 * movementMultiplier);
            isMovingBack = false;
        }
        if (isMovingLeft)
        {
            playerRB.velocity = new Vector3(-1 * movementMultiplier, playerRB.velocity.y, playerRB.velocity.z);
            isMovingLeft = false;
        }
        if (isMovingRight)
        {
            playerRB.velocity = new Vector3(1 * movementMultiplier, playerRB.velocity.y, playerRB.velocity.z);
            isMovingRight = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
