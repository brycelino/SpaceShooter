using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Will controls how fast the player can move 
    public float jumpforce = 10f; // Will control how high the player can jump
    public float turnSmoothing = 0.2f; // controls the smoothness of the player when they face  a new direction

    private float turnSmoothVelocity;
    
    private Vector2 moveInput;
    private Rigidbody rb; // declare rb to refer a rigidbody
    private Transform cam; // ref to our players camera
    public Vector3 playerGravity; // will contain the players gravity 

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask thisIsGround;
    Collider[] groundCol;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // will contain the players rigid body
    }

    void Start()// Start is called before the first frame update
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        groundCol = Physics.OverlapSphere(groundCheck.position, 0.2f, thisIsGround); // invisible sphere that checks if we're touching anything on the ground

        if(groundCol.Length > 0) // if anything on the ground is greater than 
        {
            isGrounded = true; // it is grounded
            Debug.Log("is on ground");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Not on ground");
        }

        Physics.gravity = playerGravity;
        moveInput.x = Input.GetAxisRaw("Horizontal"); // Allows the player to use A/D Left/Right to move horizontally
        moveInput.y = Input.GetAxisRaw("Vertical");// Allows the player to use W/S Up/Down to move vertically

        if (Input.GetButtonDown("Jump") && isGrounded )  // If player press jump button space do \
        {
             PlayerJump();
            Debug.Log("Jumped");
        }

        
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized; // the .normalized makes the player go the same speed at all directions 

        if(moveDirection != Vector3.zero) //if moveDirection is not equal to vector 3.0 allow the player to move
        {
            if(moveDirection.magnitude >= 0.1f) // if we're moving slighty in any direction 
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothing); // when they player faces a new direction the smoothness of the turn will be better
                transform.rotation = Quaternion.Euler(0f, angle, 0); // changes the player rotation when the player turns to a new direction. 

                Vector3 moveDirB = Quaternion.Euler(0, targetAngle, 0f) * Vector3.forward;

                rb.MovePosition(transform.position + moveDirB * moveSpeed * Time.deltaTime); // Actually allows the player to move around 

            }
        }
    }

    void PlayerJump()
    {
        rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse); // rigidbody adds force the the y axis multipled by how high we want the player to jump
    }
}
