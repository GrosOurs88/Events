using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMasterScript : MonoBehaviour
{
    public AudioSource sourceMusic;
    public AudioSource sourceSfx;
    public AudioClip musicLevel;

    void Start()
    {
        PlayMusic(musicLevel);
    }

    public void PlayMusic(AudioClip _clip)
    {
        sourceMusic.clip = _clip;
        sourceMusic.Play();
    }
}
