using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Variables")]
    [SerializeField] private float playerMaxHealth;
    [SerializeField] private float playerCurrentHealth;
    void Awake()
    {
        playerCurrentHealth = playerMaxHealth;
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
