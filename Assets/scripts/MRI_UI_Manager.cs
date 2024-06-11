using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MRI_UI_Manager : MonoBehaviour
{
    public GameObject descriptionText;
    public int pageNumber = 1;
    public int numOfPage = 3;
    public string[] textInfo = {"text1", "text2", "text3"};

    // Start is called before the first frame update
    void Start()
    {
        descriptionText.GetComponent<TextMeshPro>().text = textInfo[pageNumber - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPage()
    {
        
        if (pageNumber < numOfPage)
        {
            pageNumber++;
            descriptionText.GetComponent<TextMeshPro>().text = textInfo[pageNumber - 1];
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
