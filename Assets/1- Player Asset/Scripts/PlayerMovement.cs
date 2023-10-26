using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRB;

    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform orientation;

    [SerializeField] private Transform groundCheckTransform;    
    [SerializeField] private LayerMask groundLayer;    
    private bool isGrounded;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movementDirection;
    

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;
    }

    private void Update()
    {
        CheckGround();
        PlayerInput();
        SpeedControl();
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        playerRB.AddForce(movementDirection.normalized * movementSpeed * 10f, ForceMode.Force);
    }

    private void CheckGround()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, groundLayer).Length == 0)
        {
            isGrounded = false;            
        }
        else
        {
            isGrounded = true;            
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(playerRB.velocity.x, 0f, playerRB.velocity.z);

        if(flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            playerRB.velocity = new Vector3(limitedVel.x, playerRB.velocity.y, limitedVel.z);
        }
    }
}
