using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    // Add this function to the click event of the button
    public void LoadNextScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Only works in Exe/ Apk file, does nothing in the editor
    public void QuitGame()
    {
        Application.Quit();
    }
}
