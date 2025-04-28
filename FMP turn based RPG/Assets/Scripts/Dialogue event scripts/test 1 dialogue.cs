using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1dialogue : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] WorldDialogue dialogue;

    public bool seen = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");

        if (seen == false)
        {
            StartCoroutine(Dialogue());
        }       
    }

    private IEnumerator Dialogue()
    {
        canvas.gameObject.SetActive(true);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(true);        
        yield return dialogue.ScrollDialogue($"This is the first test.");
        yield return new WaitForSeconds(1f);
        yield return dialogue.ScrollDialogue($"This will only trigger once.");
        yield return new WaitForSeconds(1f);
        yield return dialogue.ScrollDialogue($"You will never see this again.");
        yield return new WaitForSeconds(1f);

        canvas.gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        seen = true;
    }
}
