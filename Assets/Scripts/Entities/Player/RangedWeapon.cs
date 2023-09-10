using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField] private GenericProjectile basicProjectile;
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private SpriteRenderer playerRenderer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(basicProjectile);
        projectile.transform.position = shootingPosition.transform.position;
        projectile.direction = playerRenderer.flipX ? -1 : 1;
    }
}
