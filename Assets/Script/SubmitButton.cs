using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    public Questionnaire questionnaire;
    public Click resetButton;

    public GameSpeech gameSpeech;

    public TriageSceneHandler handler;

    private bool isFormCompleted = false;

    public void ToggleObject(){
        resetButton.OffAudio();
        gameSpeech.OffAudio();
        handler.OffAudio();
        if(questionnaire.AreAllClicked()){
            isFormCompleted = true;
            GetComponents<AudioSource>()[0].Play();
            return;
        }
        GetComponents<AudioSource>()[1].Play();
    }

    public void OffAudio(){
        GetComponents<AudioSource>()[0].Stop();
        GetComponents<AudioSource>()[1].Stop();
    }

    public void Reset(){
        isFormCompleted = false;
    }

    public bool GetIsFormCompleted(){
        return isFormCompleted;
    }
}
