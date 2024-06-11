using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KeyboardInvoke : MonoBehaviour
{
        public GameObject mrtkKeyboardPrefab;

    public void OpenSystemKeyboard()
    {
        GameObject keyboard = Instantiate(mrtkKeyboardPrefab, transform.position, Quaternion.identity);
        keyboard.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        OpenSystemKeyboard();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
