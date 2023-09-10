using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private const string IDLE = "a_Idle";
    private const string RUNNING = "a_Running";
    private const string ONAIR = "a_OnAir";
    private const string JUMPING = "a_Jumping";

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        playerMovement.OnIdleEvent += OnIdleAnimation;
        playerMovement.OnRunningRightEvent += OnRunningRightAnimation;
        playerMovement.OnRunningLeftEvent += OnRunningLeftAnimation;
        playerMovement.OnAirEvent += OnAirAnimation;
        playerMovement.OnJumpingEvent += OnJumpingAnimation;
    }

    private void OnIdleAnimation()
    {
        animator.Play(IDLE);
    }

    private void OnRunningRightAnimation()
    {
        animator.Play(RUNNING);
    }

    private void OnRunningLeftAnimation()
    {
        animator.Play(RUNNING);
    }

    private void OnAirAnimation()
    {
        animator.Play(ONAIR);
    }

    private void OnJumpingAnimation()
    {
        animator.Play(JUMPING);
    }

}
