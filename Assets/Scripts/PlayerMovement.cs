using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Health Variables")]
    [SerializeField] private float playerMaxHealth;
    [SerializeField] private float playerCurrentHealth;

    [Header("Movement Variables")]
    [SerializeField] private float speedHorizontal;
    [SerializeField] private float speedJump;
    private bool horizontalInput = false;
    [SerializeField] private float runningSpeedHorizontal;

    [Header("MaxSpeed")]
    [SerializeField] private float maxSpeedHorizontal;
    [SerializeField] private float maxSpeedVertical;

    private Rigidbody2D playerRigidbody2D;

    void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerCurrentHealth = playerMaxHealth;
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
    }

    private void Movement()
    {
        horizontalInput = false;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRigidbody2D.AddForce(new Vector2(runningSpeedHorizontal, 0));
                return;
            }
            playerRigidbody2D.AddForce(new Vector2(speedHorizontal, 0));
            horizontalInput = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerRigidbody2D.AddForce(new Vector2(-runningSpeedHorizontal, 0));
                return;
            }
            playerRigidbody2D.AddForce(new Vector2(-speedHorizontal, 0));
            horizontalInput = true;
        }
        if (!horizontalInput){
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
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody2D.AddForce(new Vector2(0, speedJump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        if (playerCurrentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
