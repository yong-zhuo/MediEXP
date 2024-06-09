using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject headset;
    public GameObject clicker;
    public AudioSource audioSource;
    public GameObject scorePanel;
    public TMP_Text scoreText;
    public int[] clickTimes = new int[] { 2, 7, 13, 18, 22, 25, 37 };
    public int maxScore= 7;
    
    
    private int score = 0;
    private bool testStarted = false;

    public static TestManager Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(false);
        audioSource.enabled = false;
    }

    public void CheckTools()
    {
       if (headset.GetComponent<InteractableObject>().isEquipped)
        {
            audioSource.enabled = true;
            audioSource.Play();
            testStarted = true;
            StartCoroutine(CheckAudioEnd());
        } else
        {
            audioSource.enabled = false;
            
        }
    }
    IEnumerator CheckAudioEnd()
    {
        
        yield return new WaitWhile(() => audioSource.isPlaying);
        EndTest();
    }

    public void EndTest()
    {
        scorePanel.SetActive(true);
        scoreText.text = "You have finished the test, well done!\r\n\r\n\r\nYour score is: " + score;
        scoreText.ForceMeshUpdate();
    }

    public void IncrementScore()
    {

        if (!testStarted) return; 
        float currentTime = audioSource.time;
        Debug.Log("Current Time: " + currentTime);


        foreach (int clickTime in this.clickTimes)
        {
            
            Debug.Log("Click Time: " + clickTime);
            if (Mathf.Abs(clickTime - currentTime) < 0.5f)
            {
                Debug.Log(clickTime-currentTime);
                score++;
                score = Mathf.Min(score, maxScore); 
                break;
            }
        }
    }
}
