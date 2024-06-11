using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using Unity.VisualScripting;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{   
    public Click resetCamPos;
    public GameSpeech gameSpeech;
    private const int mode = 1;
    // Start is called before the first frame update
    public void ToggleObject(){
        resetCamPos.OffAudio();
        GetComponent<AudioSource>().Stop();
        gameSpeech.OffAudio();
        GetComponent<AudioSource>().Play();
        Debug.Log("Answer button is clicked");
    }

    public int GetMode(){
        return mode;
    }

    public void OffAudio(){
        GetComponent<AudioSource>().Stop();
    }
}
