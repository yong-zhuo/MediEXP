using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    // Start is called before the first frame update
    public void onClick()
    {
        TestManager.Instance.IncrementScore();
    }
}
