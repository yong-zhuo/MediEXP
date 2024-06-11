using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Click : MonoBehaviour 
{

    // Start is called before the first frame update
    public GameObject kamera;
    public SubmitButton submitButton;
    public GameSpeech gameSpeech;
    public TriageSceneHandler handler;

    public Questionnaire questionnaire;
    public void ToggleObject() { 
        kamera.transform.position = Vector3.zero;
        submitButton.OffAudio();
        handler.OffAudio();
        gameSpeech.OffAudio();
        submitButton.Reset();
        questionnaire.ResetChecks();
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
