using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazeevent : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] WorldDialogue dialogue;

    public bool seen = false;

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");

        if (seen == false)
        {
            canvas.gameObject.SetActive(true);
            canvas.transform.GetChild(0).gameObject.SetActive(false);
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(true);

            yield return dialogue.ScrollDialogue("You have entered the trial of flowers.");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("To complete this trial you must become one with nature and learn the path that life will guide you through");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Complete this task and you shall be granted the weapon that can restore life.");
            yield return new WaitForSeconds(1f);

            canvas.gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(false);
            seen = true;
        }
    }
}
