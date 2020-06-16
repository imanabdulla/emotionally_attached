using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAndMap : MonoBehaviour
{
    private void Start()
    {
        AudioClip[] clips = new AudioClip[1];
        float[] volumes = new float[1];
        clips[0] = AudioManager.audioManager.musicClip.birdsSound;
        volumes[0] = 1f;
        AudioManager.audioManager.PlayMusic(clips, volumes, true);

        FindObjectOfType<BillsAndWallets>().GetComponent<Canvas>().enabled = false;
    }
}
