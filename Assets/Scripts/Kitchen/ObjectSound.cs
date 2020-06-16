using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSound : MonoBehaviour
{
    private void OnDisable()
    {
        EndSound();
    }

    void StartSound(AudioClip clip)
    {
        AudioManager.audioManager.PlaySound(clip, false, 1f);
    }

    void StartSoundRepeatly(AudioClip clip)
    {
        AudioManager.audioManager.PlaySound(clip, true, 1f);
    }

    void EndSound()
    {
        AudioManager.audioManager.StopSound();
    }
}
