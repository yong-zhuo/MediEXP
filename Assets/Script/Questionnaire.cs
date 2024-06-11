using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questionnaire : MonoBehaviour
{
    public int ButtonNum;
    private const int NumOfButtons = 3;
    private static bool[] CheckClicked = {false, false, false};
    public void ToggleObject(){
        CheckClicked[ButtonNum - 1] = true;
    }

    public bool AreAllClicked(){
        return CheckClicked[0] && CheckClicked[1] && CheckClicked[2];
    }

    public void ResetChecks(){
        for(int i = 0; i < 3; i++){
            CheckClicked[i] = false;
        }

    }
}
