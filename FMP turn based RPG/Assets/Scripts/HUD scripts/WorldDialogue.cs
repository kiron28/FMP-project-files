using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WorldDialogue : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] int letterspersecond;
    [SerializeField] GameObject canvas;

    public bool firstitem = false;

    public event Action DialogueStart;
    public event Action DialogueEnd;

    public void SetDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }


    public IEnumerator ScrollDialogue(string dialogue)
    {
        dialogueText.text = "";
        
        foreach (var letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / letterspersecond);            
        }        
    }

   
}
