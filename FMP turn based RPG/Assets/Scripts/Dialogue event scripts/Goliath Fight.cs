using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathFight : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] WorldDialogue dialogue;
    [SerializeField] Gamecontroller controller;
    [SerializeField] BattleSystem battle;
    [SerializeField] Enemy goliath;

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

            yield return dialogue.ScrollDialogue("Christina: Wooo Monster fighting time!");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Nathan: Can you stop being so carefree for one second? It's gonna get us killed.");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Christina: But I've been waiting so long doing all the boring stuff to 'prepare'. I Just wanna fight this thing.");
            yield return new WaitForSeconds(1f);
            yield return dialogue.ScrollDialogue("Jasper: Can you two stop bickering for a moment please. Look, here its comes!");
            yield return new WaitForSeconds(1f);

            canvas.gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.01f);
            controller.BossBattle();
           
            seen = true;

        }
    }
}
