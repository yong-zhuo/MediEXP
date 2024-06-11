using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeech : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSrc;
    public static bool initialPlay = true;
    public void Start(){
        
        audioSrc = GetComponent<AudioSource>();
        PlayAudio();
    }
    public void PlayAudio(){
        audioSrc.Play();
    }

    public void OffAudio(){
        audioSrc.Stop();
        initialPlay = false;
    }

    public bool getInitialPlay(){
        return initialPlay;
    }
}
