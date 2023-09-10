using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEntity : MonoBehaviour
{
    [Header("Health Variables")]
    [SerializeField] private float maxHealth = 1;
    [SerializeField] private float currentHealth = 1;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
}
