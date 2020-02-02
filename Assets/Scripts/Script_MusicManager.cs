using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_MusicManager : MonoBehaviour
{
    public static Script_MusicManager Instance { get; private set; }
    private AudioSource audioComp;
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this); 
        }

        audioComp = GetComponent<AudioSource>();
    }



    public void PlayMenuMusic()
    {
        audioComp.pitch = 1f;
        audioComp.clip = menuMusic;
        audioComp.Play();
    }

    public void PlayGameMusic()
    {
        audioComp.pitch = 1.05f;
        audioComp.clip = gameMusic;
        audioComp.Play();
    }

    public void StopMusic()
    {
        audioComp.Stop();
    }
}
