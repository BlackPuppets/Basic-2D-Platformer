using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioPlayerController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClipList;
    [SerializeField] private AudioClip audioClipJump;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayAudio()
    {
        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSource.Play();
    }

    private void PlayJumpAudio()
    {
        Debug.Log("chamo");
        audioSource.clip = audioClipJump;
        audioSource.Play();
    }
}
