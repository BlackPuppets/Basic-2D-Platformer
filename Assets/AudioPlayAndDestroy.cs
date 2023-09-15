using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayAndDestroy : MonoBehaviour
{
    private AudioSource externalAudioSource;

    public void PlayAudio(AudioSource audioSource)
    {
        externalAudioSource = Instantiate(audioSource);
        externalAudioSource.Play();
    }

    private void Update()
    {
        if (externalAudioSource != null)
        {
            if (!externalAudioSource.isPlaying)
            {
                DestroyAudio();
            }
        }
    }

    private void DestroyAudio()
    {
        Destroy(externalAudioSource);
    }
}
