using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Dialogue : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] WorldDialogue dialogue;

    public bool seen = false;

    private IEnumerator OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Collided");
        
        if (seen == false && Input.GetKeyDown(KeyCode.E))
        {
            canvas.gameObject.SetActive(true);
            canvas.transform.GetChild(3).gameObject.SetActive(true);

            yield return dialogue.ScrollDialogue($"This is the second test.");
            yield return dialogue.ScrollDialogue($"This dialogue is completely different than the last text.");
            yield return dialogue.ScrollDialogue($"You will also never see this again.");

            canvas.gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(false);
            seen = true;
        }
    }
}
