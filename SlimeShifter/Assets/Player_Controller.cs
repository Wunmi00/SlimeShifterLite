using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Player_Controller : MonoBehaviour
{
    
    private CharacterController controller;
    private Input_Manager InputManager;
    private Vector2 playerVelocity;
    private bool playerGrounded;
    private Player_Movement player;

    //private SwipeDetection swipe;


    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float jumpHeight = 5.0f;
    [SerializeField]
    private float gravity = -9.81f;

    public Animator animator;

    private void Awake()
    {
        player = new Player_Movement();
        controller = GetComponent<CharacterController>();
        //swipe = SwipeDetection.Instance;

    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }

    private void playerJump()
    {
        if (player.PlayerMove.Jump.triggered && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void playerMove()
    {
        
        
        //if the player is grounded & their movement in the Y direction is > 0, then their Velocity in the Y direction is 0
        playerGrounded = controller.isGrounded;
        if (playerGrounded && playerVelocity.y < 0)
        {

            playerVelocity.y = 0f;
        }
        ///new
        Vector2 input = player.PlayerMove.Move.ReadValue<Vector2>();
        Vector2 move = new Vector2(input.x, 0f);

        controller.Move(move * Time.deltaTime * playerSpeed);

        animator.SetFloat("Speed", Mathf.Abs(move.x));


    }

   



    // Update is called once per frame
    void Update()
    {
        playerMove();

        playerJump();
    }

   
}