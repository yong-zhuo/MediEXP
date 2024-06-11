using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriageSceneHandler : MonoBehaviour
{

    public SubmitButton submitButton;
    public Click resetButton;
    public GameSpeech gameSpeech;
    // Add this function to the click event of the button
    public void LoadNextScene(string nextSceneName)
    {
        if(submitButton.GetIsFormCompleted()){
            SceneManager.LoadScene(nextSceneName);
            return;
        }
        resetButton.OffAudio();
        gameSpeech.OffAudio();
        submitButton.OffAudio();
        GetComponent<AudioSource>().Play();
    }

    public void OffAudio(){
        GetComponent<AudioSource>().Stop();
    }

    // Only works in Exe/ Apk file, does nothing in the editor
    public void QuitGame()
    {
        Application.Quit();
    }
}
