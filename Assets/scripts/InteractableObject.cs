using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isEquipped = false;
    
    public void onClick()
    {
        isEquipped = true;
        this.gameObject.SetActive(false);
        TestManager.Instance.CheckTools();
    }
}
