using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : GenericEntity
{
    [SerializeField] private string playerTag = "Player";
    private Animator enemyAnimator;

    const string ATTACKING = "a_Attacking";

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(playerTag))
        {
            collision.gameObject.GetComponent<GenericEntity>().TakeDamage(1);
            enemyAnimator.Play(ATTACKING);
        }
    }
}
