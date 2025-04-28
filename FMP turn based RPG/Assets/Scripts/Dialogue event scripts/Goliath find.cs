using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goliathfind : MonoBehaviour
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

            yield return dialogue.ScrollDialogue("Christina: Guys look, it's that strong monster from before! Let's go get our revenge.");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Jasper: Right on Chris, I've been waiting for this. Didn't expect to find it so close though.");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Nathan: I'm not so sure guys. There's a reason we had to run last time. It was way too strong then and if we're prepared enough we'll be too weak to fight it now.");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Chistina: Uggh, why you gotta be so boring all the time Nath. Can't we fight something strong just this once?");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Jasper: Hate to say it but he's right Chris. How about this? If we train up and get stronger, you happy to try fight it?");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Nathan: I guess that seems like a fair compromise. And I'd be lying if I said I didn't also want a bit of revenge.");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Jasper: That's the spirit! You happy with that then Chris?");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Chistina: Pfft, I guess. you're such a spoilsport Nath...");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Nathan: Oii what did you say?!?");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Chistina: Nothingggggggg!");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("(Recommended level for Goliath is Level 10)");
            yield return new WaitForSeconds(1f);

            canvas.gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(false);
            seen = true;
        }
    }
}
