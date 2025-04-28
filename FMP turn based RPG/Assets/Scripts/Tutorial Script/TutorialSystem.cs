using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TutorialSystem : MonoBehaviour
{
    [SerializeField] BattleSystem main;
    [SerializeField] Button Skill;
    [SerializeField] Button Run;
    [SerializeField] Button Defend;
    [SerializeField] Button Attack;
    [SerializeField] FightDialogue dialogueBox;
    [SerializeField] Leavetutorial leave;



    public IEnumerator TutorialStart()
    {
        yield return dialogueBox.ScrollDialogue("This is your first battle.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("Here we will learn the simple attacks that you can perform.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("First, lets perform an attack.");
        yield return new WaitForSeconds(0.5f);

        Skill.interactable = false;
        Run.interactable = false;
        Defend.interactable = false;
        StartCoroutine(main.PlayerTurn());
    }

    public IEnumerator TutorialSkill()
    {
        yield return dialogueBox.ScrollDialogue("Next we will perform a skill.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("You gain skills by levelling up.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("The skills you can use will depend on the weapon and elementa that you have equipped.");
        yield return new WaitForSeconds(0.5f);
        
        Skill.interactable = true;
        Defend.interactable = false;
        Attack.interactable = false;
        StartCoroutine(main.PlayerTurn());
    }

    public IEnumerator TutorialDefend()
    {
        yield return dialogueBox.ScrollDialogue("Finally lets try defending to prevent incoming damage");
        yield return new WaitForSeconds(0.5f);

        Skill.interactable = false;        
        Defend.interactable = true;
        Attack.interactable = false;
        StartCoroutine(main.PlayerTurn());
    }

    public IEnumerator Tutorial1Finish()
    {
        yield return dialogueBox.ScrollDialogue("That is the end of your first battle tutorial.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("With the knowledge you have, you should now be able to win this on your own.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("Good luck!");
        yield return new WaitForSeconds(0.5f);

        Skill.interactable = true;
        Defend.interactable = true;
        Attack.interactable = true;
        StartCoroutine(main.PlayerTurn());
    }

    public IEnumerator Tutorial1End()
    {
        yield return dialogueBox.ScrollDialogue("Well done in completing your first fight and gaining a level for the whole party.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("With that you will have better stats and will also know a new skill.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("Do note though that party members that are knocked at the end of a fight do not gain experience.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("You will also notice that after every fight you heal, meaning you can explore more!");
        yield return new WaitForSeconds(1f);
        main.TutorialEnd();
    }

    public IEnumerator Tutorial2Start()
    {
        yield return dialogueBox.ScrollDialogue("Uh oh... this monster seems a bit too strong for you.");
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(main.EnemyTurn());
    }

    public IEnumerator Tutorial2Knock()
    {
        yield return dialogueBox.ScrollDialogue("That's not good. One of your party members is down.");
        yield return new WaitForSeconds(0.5f);
        yield return dialogueBox.ScrollDialogue("We need to run away from this monster. It's too strong for you.");
        yield return new WaitForSeconds(0.5f);

        Skill.interactable = false;
        Run.interactable = true;
        Defend.interactable = false;
        Attack.interactable = false;
        leave.DoneTutorial = true;
        StartCoroutine(main.PlayerTurn());
    }
}
