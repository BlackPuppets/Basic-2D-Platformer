using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Variables")]
    [SerializeField] private float speedHorizontal;
    [SerializeField] private float speedJump;
    private bool horizontalInput = false;
    [SerializeField] private float runningSpeedHorizontal;

    [Header("MaxSpeed")]
    [SerializeField] private float maxSpeedHorizontal;
    [SerializeField] private float maxSpeedVertical;

    private Rigidbody2D playerRigidbody2D;
    private SpriteRenderer spriteRenderer;

    [Header("GroundedControl")]
    [SerializeField] public Transform top_left;
    [SerializeField] public Transform bottom_right;
    [SerializeField] public LayerMask ground_layers;
    private bool isGrounded = true;
    private bool canChangeDirectionOnAir = false;

    #region animationEvents
    public delegate void OnIdle();
    public event OnIdle OnIdleEvent;

    public delegate void OnRunningRight();
    public event OnRunningRight OnRunningRightEvent;

    public delegate void OnRunningLeft();
    public event OnRunningLeft OnRunningLeftEvent;

    public delegate void OnAir();
    public event OnAir OnAirEvent;

    public delegate void OnJumping();
    public event OnJumping OnJumpingEvent;

    #endregion

    void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Idealmente alterar para inputs serem feitos no Update e funções q envolvem a aplicação de força e velocidade do Rigidbody no FixedUpdate
    private void Update()
    {
        Movement();
        Jump();
    }
    private void FixedUpdate()
    {
        ControlMaxSpeed();
        ControlIsGrounded();
    }

    private void Movement()
    {
        horizontalInput = false;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horizontalInput = true;
            if (isGrounded)
            {
                OnRunningRightEvent();
                spriteRenderer.flipX = false;
            }
            else if(canChangeDirectionOnAir){
                spriteRenderer.flipX = false;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRigidbody2D.AddForce(new Vector2(runningSpeedHorizontal, 0));
                return;
            }
            playerRigidbody2D.AddForce(new Vector2(speedHorizontal, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horizontalInput = true;
            if (isGrounded)
            {
                OnRunningLeftEvent();
                spriteRenderer.flipX = true;
            }
            else if (canChangeDirectionOnAir)
            {
                spriteRenderer.flipX = true;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRigidbody2D.AddForce(new Vector2(-runningSpeedHorizontal, 0));
                return;
            }
            playerRigidbody2D.AddForce(new Vector2(-speedHorizontal, 0));
        }
        else if (!horizontalInput){
            StopHorizontalMovement();
            return;
        }
    }

    private void ControlMaxSpeed()
    {
        playerRigidbody2D.velocity = new Vector2(Mathf.Clamp(playerRigidbody2D.velocity.x, -maxSpeedHorizontal, maxSpeedHorizontal), Mathf.Clamp(playerRigidbody2D.velocity.y, -maxSpeedVertical, maxSpeedVertical));
    }

    private void StopHorizontalMovement()
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x * 0.8f, playerRigidbody2D.velocity.y);
        if (isGrounded)
        {
            OnIdleEvent();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody2D.AddForce(new Vector2(0, speedJump));
            OnJumpingEvent();
        }
    }

    private void ControlIsGrounded()
    {

        isGrounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);

        if (!isGrounded)
        {
            OnAirEvent();
        }

        if (isGrounded)
        {
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, 0);
        }

    }

    public void CanChangeJumpDirection()
    {
        canChangeDirectionOnAir = !canChangeDirectionOnAir;
    }

}
