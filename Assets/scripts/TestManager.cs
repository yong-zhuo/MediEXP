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
    public GameObject nextScenePanel;
    //public int[] clickTimes = new int[] { 2, 7, 13, 18, 22, 25, 37 };
    public int maxScore= 8;
    public int totalTestDuration = 45;
    public AudioClip[] audioClips;


    private List<float> clickTimes = new List<float>();
    private int score = 0;
    private bool testStarted = false;
    private string passStatus = "failed";
    private int misclicks = 0;

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
        nextScenePanel.SetActive(false);
        scorePanel.SetActive(false);
        audioSource.enabled = false;
    }

    public void CheckTools()
    {
       if (headset.GetComponent<InteractableObject>().isEquipped)
        {
            
            //start the test
            testStarted = true;

            //generate the click times randomly
            GenerateClickTimes();

            //start a coroutine to play the audio
            StartCoroutine(StartPlayback());

            
            
        } else
        {
            //shouldn't reach here i think(?) but just in case
            audioSource.enabled = false;
            
        }
    }
    private IEnumerator StartPlayback()
    {
        audioSource.enabled = true;

        

        foreach (float playTime in clickTimes)
        {
            
            float delay = playTime - Time.time;

            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }
            float minVolume = 0.3f;
            float maxVolume = 0.7f;
            audioSource.volume = Random.Range(minVolume, maxVolume);
            //Debug.Log("Playing sound at: " + Time.time + " " + audioSource.volume);
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
        
        EndTest();
    }

    private void GenerateClickTimes()
    {
        this.clickTimes.Clear();
        float startTime = Time.time;

        //initial start time
        float currentTime = Random.Range(2.0f, 5.0f);
        this.clickTimes.Add(currentTime + startTime);

        for (int i = 1; i < this.maxScore; i++)
        {
            //2 seconds gap between each sound
            float nextTime = currentTime + Random.Range(2.0f, (totalTestDuration - currentTime) / (maxScore - i));

           
            if (nextTime > totalTestDuration - 2.0f)
            {
                break;
            }

            this.clickTimes.Add(nextTime + startTime);
            currentTime = nextTime;
        }

        //fill the rest of the list with random times
        while (clickTimes.Count < maxScore)
        {
            float remainingTime = totalTestDuration - currentTime - 2.0f;
            float nextTime = currentTime + Random.Range(2.0f, remainingTime > 2.0f ? remainingTime : 2.0f);

            this.clickTimes.Add(nextTime + startTime);
            currentTime = nextTime;
        }

        clickTimes.Sort();
    }

    public void EndTest()
    {
        if (score >= maxScore / 2)
        {
            this.passStatus = "passed";
        }
        scorePanel.SetActive(true);
        scoreText.text = "You have finished the test.\r\n\r\n\r\nYou have managed to identified the sound " + score + " times and misclicked " + misclicks + " times.\r\n\r\n\r\nYou have " + passStatus + " the test.\r\n\r\n\r\nPlease return to the door to proceed to the next station.";
        scoreText.ForceMeshUpdate();
        nextScenePanel.SetActive(true);
    }

    public void IncrementScore()
    {

        if (!testStarted) return; 
        float currentTime = Time.time;
        bool clickedInRange = false;
        //Debug.Log("Current Time: " + currentTime);


        foreach (float clickTime in this.clickTimes)
        {
            
            //Debug.Log("Click Time: " + clickTime);
            if (Mathf.Abs(clickTime - currentTime) < 0.6f)
            {
                //Debug.Log(clickTime-currentTime);
                clickedInRange = true;
                break;
            } 
            
        }

        if (clickedInRange)
        {
            score++;
            score = Mathf.Min(score, maxScore);
        }
        else
        {
            
            misclicks++;
        }
    }
}