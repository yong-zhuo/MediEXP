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

    // Start is called before the first frame update
    void Start()
    {
        descriptionText.GetComponent<TextMeshPro>().text = textInfo[pageNumber - 1];
        // Hardcoded
        endPos.Set(2.52399993f, -0.402999997f, 3.9690001f);
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
            vrCamera.transform.position = new Vector3(2.52399993f, -0.402999878f, 2.50900006f);
            vrCamera.transform.Rotate(-90.0f, -180.0f, 0.0f);
            onBed = true;
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
}
