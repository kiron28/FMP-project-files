using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckingDialogue : MonoBehaviour
{
    public event Action DialogueStart;
    public event Action DialogueEnd;


    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            Debug.Log("Opened.");
            DialogueStart();
        }
        else if (gameObject.activeSelf == false)
        {
            Debug.Log("Closed");
            DialogueEnd();
        }
    }
}
