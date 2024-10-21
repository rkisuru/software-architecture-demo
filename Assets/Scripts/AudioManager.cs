using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        Bubble.OnBubblePop += PlayPopAudio;
    }

    private void OnDisable()
    {
        Bubble.OnBubblePop -= PlayPopAudio;
    }

    private void PlayPopAudio() => audioSource.Play();
}
