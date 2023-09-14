using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Vector3 playerVelocity;
    Vector3 move;
    public GameObject CharacterPlaceholder;
    Vector3 originalPlayerPosition;
    public float walkSpeed = 5;
    public float runSpeed = 8; 
    public float jumpHeight = 2;
    public float gravity = -9.18f;
    float rotationY =0.0f;
    float verticalInput = 0.0f;
    float horizontalInput = 0.0f;
    public float speedValue = 50.0f;
    public float rotationSpeed = 200.0f;
    bool isGrounded;
    public float timeSlow = 0.5f;
    private CharacterController controller;
    public float PlayerHealth;
    //private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        originalPlayerPosition = CharacterPlaceholder.transform.position;
    }

    public void Update()
    {
        ProcessMovement();
        ProcessGravity();
        SlowDownTime();
        Death();
    }

    public void LateUpdate()
    {
       UpdateAnimator();
    }

    void DisableRootMotion()
    {
        //animator.applyRootMotion = false;  
    }

    void UpdateAnimator()
    {

    }

    void ProcessMovement()
    { 
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 fowardMovement = Input.GetAxis("Vertical") * transform.forward;
        Vector3 rightMovement = Input.GetAxis("Horizontal") * transform.right;
        move = (fowardMovement + rightMovement);
        float mouseX = Input.GetAxis("Mouse X");
        
        rotationY += mouseX*Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0.0f,rotationY,0.0f);

        controller.Move(move * Time.deltaTime * GetMovementSpeed());
    }

    //Movement script!
    public void ProcessGravity()
    {
        
        // Since there is no physics applied on character controller we have this applies to reapply gravity
        
        if (isGrounded  )
        {
            if (playerVelocity.y < 0.0f) // we want to make sure the players stays grounded when on the ground
            {
                playerVelocity.y = -1.0f;
            }
            
            if (Input.GetButtonDown("Jump")) // Code to jump
            {
                playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }
        else // if not grounded
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }       

        controller.Move(playerVelocity * Time.deltaTime);
        isGrounded = controller.isGrounded;
    }

     float GetMovementSpeed()
     {
        return walkSpeed;
    //     if (Input.GetButton("Fire3"))// Left shift
    //     {
    //         return runSpeed;
    //     }
    //     else
    //     {
    //         return walkSpeed;
    //     }
     }

     void SlowDownTime()
     {
        if(Input.GetButtonDown("Fire3"))
        {
            Time.timeScale = timeSlow;
        }
        if(Input.GetButtonUp("Fire3"))
        {
            Time.timeScale = 1f;
        }
     }

     public void Death()
    {
        if(PlayerHealth == 0)
        {
             CharacterPlaceholder.transform.position = originalPlayerPosition;
             PlayerHealth= 100;
        }
    }
}
