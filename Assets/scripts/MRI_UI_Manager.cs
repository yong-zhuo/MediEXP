using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MRI_UI_Manager : MonoBehaviour
{
    public GameObject vrCamera;
    public GameObject introPanel;
    public GameObject descriptionText;
    public GameObject simulationPanel;
    public int pageNumber = 1;
    public int numOfPage = 3;
    public string[] textInfo = {"text1", "text2", "text3"};
    public bool onBed = false; // will be true when player lying on bed
    public Vector3 endPos;
    public float speed = 0.1f;
    public GameObject startButton;
    public GameObject exitButton;
    public AudioSource[] audioLib;

    // Start is called before the first frame update
    void Start()
    {
        descriptionText.GetComponent<TextMeshPro>().text = textInfo[pageNumber - 1];
        // Hardcoded
        //endPos.Set(2.52399993f, -0.402999997f, 3.9690001f);
        endPos.Set(0.125f, -0.5f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (onBed)
        {
            var step = speed * Time.deltaTime; ;
            vrCamera.transform.position = Vector3.MoveTowards(vrCamera.transform.position, endPos, step);
        }
    }

    public void NextPage()
    {
        if (pageNumber < numOfPage)
        {
            pageNumber++;
            descriptionText.GetComponent<TextMeshPro>().text = textInfo[pageNumber - 1];
        }
        else
        {
            introPanel.SetActive(false);
            simulationPanel.SetActive(true);

            // Maybe can lerp ?
            vrCamera.transform.position = new Vector3(0.125f, -0.4f, 2.0f);
            vrCamera.transform.Rotate(-90.0f, -180.0f, 0.0f);
            onBed = true;
            audioLib[1].Play();
        }
    }

    public void PrevPage()
    {
        if (pageNumber > 1)
        {
            pageNumber--;
            descriptionText.GetComponent<TextMeshPro>().text = textInfo[pageNumber - 1];
        }
    }

    public void StartSimulation()
    {
        audioLib[0].Play();
        startButton.SetActive(false);
        exitButton.SetActive(true);
    }

}
