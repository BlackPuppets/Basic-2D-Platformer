using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollectable : MonoBehaviour
{
    [SerializeField] protected Transform particleEffect;

    [Header("Sounds")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioPlayAndDestroy audioPlayAndDestroy;

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

    protected virtual void OnCollect() {
        PlayEffect();
        if(audioSource != null) audioPlayAndDestroy.PlayAudio(audioSource);
    }
    
    protected virtual void PlayEffect() { }
}
