using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenericProjectile : MonoBehaviour
{
    [SerializeField]private Vector3 speed;
    [SerializeField]private float lifetime = 1;
    public int direction = 1;

    [SerializeField] private string enemyString = "Enemy";

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyString)){
            collision.GetComponent<GenericEntity>().TakeDamage(1);
        }
    }
}
