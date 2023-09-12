using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEntity : MonoBehaviour
{
    [Header("Health Variables")]
    [SerializeField] private SOEntity soEntity;

    void Awake()
    {
        soEntity.currentHealth = soEntity.maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        soEntity.currentHealth -= damage;
        if (soEntity.currentHealth <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
}
