using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_Move : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float jumpHeight = 15.0f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private Vector2 playerVelocity;

    private bool isJumping;

    private Rigidbody2D rBody;
    private Player_Movement player; //Input actions
    private Input_Manager inputManager; //Input manager
    private BoxCollider2D boxCollider;

    public Animator animator;

    private void Awake()
    {
        player = new Player_Movement();
        rBody = GetComponent<Rigidbody2D>();
        boxCollider = transform.GetComponent<BoxCollider2D>();
        isJumping = false;
    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }

    private void playerMove()
    {

        var input = player.PlayerMove.Move.ReadValue<Vector2>();
        var velocity = playerSpeed * input;
        rBody.velocity = new Vector2(velocity.x, 0f);
        animator.SetFloat("Speed", Mathf.Abs(velocity.x));
    }

    private void playerJump()
    {
        if (player.PlayerMove.Jump.triggered && isGrounded())
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
           
            rBody.velocity = new Vector2(0f, playerVelocity.y);
        }
       

    }

    private void FixedUpdate()
    {
        playerMove();


        playerJump();


    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, 
            boxCollider.bounds.size, 0f, Vector2.down * 0.1f);
        Debug.DrawRay(transform.position, Vector3.down, Color.red, 0.1f);
        return raycastHit.collider != null;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Ground")
    //    {
    //        isJumping = false;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Ground")
    //    {
    //        isJumping = true;
    //    }
    //}
}
