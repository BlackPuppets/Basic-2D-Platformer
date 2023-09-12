using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        Destroy(gameObject);
    }

    protected virtual void OnCollect() { }
}