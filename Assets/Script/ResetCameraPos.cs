using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Keyboard;
using UnityEngine;

public class Click : MonoBehaviour 
{

    // Start is called before the first frame update
    public GameObject kamera;
    public AnswerButton answerButton;
    public GameSpeech gameSpeech;
    public void ToggleObject() { 
        kamera.transform.position = Vector3.zero;
        answerButton.OffAudio();
        gameSpeech.OffAudio();
        GetComponents<AudioSource>()[0].Play();
    }

    public void OffAudio(){
        GetComponents<AudioSource>()[0].Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
