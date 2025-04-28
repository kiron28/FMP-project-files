using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTutorial : MonoBehaviour
{
    [SerializeField] BattleSystem battle;
    [SerializeField] WorldDialogue dialogueBox;
    [SerializeField] Canvas canvas;
    [SerializeField] Gamecontroller controller;
    public bool TutorialStart = true;
    public bool MenuOpen = false;
    public bool partyopen = false;
    public bool itemequip = false;

    public IEnumerator Tutorialmenu()
    {
        canvas.gameObject.SetActive(true);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        yield return dialogueBox.ScrollDialogue("Jasper: Nathan that skill you used... How did you do that?");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("Nathan: I think it was those wood knuckles we bought in town. I bought this shield too.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("You should try equipping it.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("(Press escape to open up the menu)");
        yield return new WaitForSeconds(0.5f);
        TutorialStart = false;
        controller.IsTutorial = false;
        //controller.state = GameState.Exploration;
    }

    public IEnumerator TutorialParty()
    {
        TutorialStart = true;
        controller.IsTutorial = true;
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        yield return dialogueBox.ScrollDialogue("(Now select the party option in the menu.)");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator TutorialChar()
    {
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        yield return dialogueBox.ScrollDialogue("(Now select Jasper by clicking them.)");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator TutorialInv()
    {
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        yield return dialogueBox.ScrollDialogue("(In this menu, you will be able to see each party member's stats, skills and type affinities)");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("(You will also be able to change equipment. For now let's just equip Jasper with the shield)");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("(Select the weapon button and then select the Rusty shield from the menu.)");
        yield return new WaitForSeconds(0.5f);
    }

    public void TutorialpreEquip()
    {
        StartCoroutine(TutorialEquip());
    }

    public IEnumerator TutorialEquip()
    {
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        yield return dialogueBox.ScrollDialogue("(With the rusty shield now equipped, Jasper will have gained new skills to use in battle)");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("(As you explore the world you will find more weapons, armour and elementa to help you build your party however you want.)");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("(Use these different combinations to help you overcome all the challenges you will find in the world)");
        yield return new WaitForSeconds(0.5f);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        yield return dialogueBox.ScrollDialogue("Christina: Damn Jas, you're really rocking that shield. You look a natural with it.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("Nathan: Well let's not get ahead of ourselves. He hasn't used it yet.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("Jasper: That might be true but neither had you with those knuckles and you were able to use them just fine.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("Nathan: I suppose you're right. Lets just keep moving, the monsters can be dangerous around here.");
        yield return new WaitForSeconds(0.5f);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
    }
}
