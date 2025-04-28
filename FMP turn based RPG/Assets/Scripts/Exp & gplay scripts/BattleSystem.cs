using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public enum FightState { Start, Attack, Busy, BattleOver}


public class BattleSystem : MonoBehaviour
{
    [SerializeField] FighterUnit playerUnit1;
    
    [SerializeField] FighterUnit playerUnit2;
    
    [SerializeField] FighterUnit playerUnit3;
    
    [SerializeField] FighterUnit enemyUnit;    
    
    [SerializeField] FightDialogue dialogueBox;

    [SerializeField] GameObject Buttons;
    [SerializeField] GameObject SkillsMenu;

    [SerializeField] PlayerController playerController;  
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera battlecamera;

    [SerializeField] List<FighterUnit> party;
    [SerializeField] Party playerparty;

    [SerializeField] TutorialSystem tutorial;
    [SerializeField] TMP_Text eLevel;    

    int currentSkill;

    int partyUnitsDead;

    FightState state;
    
    int activeMember = 0;

    FighterUnit Allytarget;

    Enemy Monster;

    public bool Tutorial1 = false;
    public bool Tutorial1Attack = false;
    public bool Tutorial1Skill = false;
    public bool Tutorial1Defend = false;
    public bool Tutorial2 = false;
    
    public event Action<bool> BattleOver;

    public void StartBattle(Enemy monster)
    {
        party.Clear();
        this.Monster = monster;
        StartCoroutine(BattleSetup());
    }


    public IEnumerator BattleSetup()
    {
        playerUnit1.Setup(playerparty.Partymembers[0]);        
        party.Add(playerUnit1);

        playerUnit2.Setup(playerparty.Partymembers[1]);
        party.Add(playerUnit2);

        playerUnit3.Setup(playerparty.Partymembers[02]);
        party.Add(playerUnit3);

        enemyUnit.Setup(Monster);

        activeMember = 0;
        partyUnitsDead = 0;

        dialogueBox.SetSkillNames(party[activeMember].Enemy.Skills);
        dialogueBox.SetSkillStamina(party[activeMember].Enemy.Skills);
        if (Tutorial1 == true && Tutorial2 == false)
            eLevel.text = "Lvl ???";
        yield return dialogueBox.ScrollDialogue($"You were ambushed by a {enemyUnit.Enemy.template.Name}.");

        yield return new WaitForSeconds(1f);

        if (Tutorial1 ==false)
        {
            StartCoroutine(tutorial.TutorialStart());
        }
        else if (Tutorial2 == false)
        {            
            StartCoroutine(tutorial.Tutorial2Start());
        }
        else
            StartCoroutine(PlayerTurn());
              
    }

    public IEnumerator PlayerTurn()
    {
        state = FightState.Attack;       
        dialogueBox.SetSkillNames(party[activeMember].Enemy.Skills);
        dialogueBox.SetSkillStamina(party[activeMember].Enemy.Skills);
        party[activeMember].Enemy.StaminaRegen();

        if (party[activeMember].Enemy.IsDefending == true)
        {
            party[activeMember].Enemy.StaminaRegen();
            party[activeMember].Enemy.IsDefending = false;
            party[activeMember].Enemy.Defending();
            yield return dialogueBox.ScrollDialogue($"{party[activeMember].Enemy.template.Name} is no longer defending.");
        }
        yield return party[activeMember].Hud.UpdateHP();
        if (Tutorial1Attack == false)
        {
            yield return dialogueBox.ScrollDialogue("Select the green attack button to deal a simple hit with no type.");            
        }
        else if (Tutorial1Attack == true && Tutorial1Skill == false)
        {
            yield return dialogueBox.ScrollDialogue("Select the red skill button and use the skill that you have available.");
        }
        else if (Tutorial1Skill == true && Tutorial1Defend == false)
        {
            yield return dialogueBox.ScrollDialogue("Select the blue defend button to brace and minimise incoming damage.");
        }
        else if (Tutorial1 == true && Tutorial2 == false)
        {
            yield return dialogueBox.ScrollDialogue("Select the white run button to escape this fight!");
        }
        else
            yield return dialogueBox.ScrollDialogue($"{party[activeMember].Enemy.template.Name}, Select an action.");

        Buttons.gameObject.SetActive(true);
    }

    public IEnumerator Defending()
    {
        yield return dialogueBox.ScrollDialogue($"{party[activeMember].Enemy.template.Name} prepared themselves for incoming attacks.");
        yield return new WaitForSeconds(1f);

        if (activeMember < party.Count - 1)
        {
            activeMember++;
            if (state == FightState.Attack)
                StartCoroutine(PlayerTurn());
        }
        else
        {
            activeMember = 0;
            if (state == FightState.Attack)
                StartCoroutine(EnemyTurn());
        }
    }

    public IEnumerator normalattack()
    {
        var attack = party[activeMember].Enemy.Attack;

        yield return PerformMove(party[activeMember], enemyUnit, attack);

        if (Tutorial1Attack == false)
        {
            Tutorial1Attack = true;
            activeMember++;
            StartCoroutine(tutorial.TutorialSkill());
        }
        else
        {
            if (activeMember < party.Count - 1)
            {
                activeMember++;
                if (state == FightState.Attack)
                    StartCoroutine(PlayerTurn());
            }
            else
            {
                activeMember = 0;
                if (state == FightState.Attack)
                    StartCoroutine(EnemyTurn());
            }
        }
    }


    public IEnumerator skillAttack()
    {
        var skill = party[activeMember].Enemy.Skills[currentSkill];
        if (party[activeMember].Enemy.Stam >= skill.Skillt.Stamina)
        {
            var target = enemyUnit;

            if (skill.Skillt.Target == SkillTarget.Self)
            {
                target = party[activeMember];
            }
            else if (skill.Skillt.Target == SkillTarget.Enemy)
            {
                target = enemyUnit;
            }
            else if (skill.Skillt.Target == SkillTarget.Ally)
            {
                target = Allytarget;
            }
                        
            yield return PerformMove(party[activeMember], target, skill);

            if (Tutorial1Skill == false)
            {
                Tutorial1Skill = true;
                activeMember++;
                StartCoroutine(tutorial.TutorialDefend());
            }
            else
            {
                if (activeMember < party.Count - 1)
                {
                    activeMember++;
                    Debug.Log(party.Count);
                    if (state == FightState.Attack)
                        StartCoroutine(PlayerTurn());
                }
                else
                {
                    activeMember = 0;
                    Debug.Log("enemy phase");
                    if (state == FightState.Attack)
                        StartCoroutine(EnemyTurn());
                }
            }                   
        }
        else
        {
            yield return dialogueBox.ScrollDialogue($"{party[activeMember].Enemy.template.Name} is too tired to use {skill.Skillt.Name}.");
            yield return new WaitForSeconds(1f);            

            {
                StartCoroutine(PlayerTurn());
            }

        }
    }

    public IEnumerator EnemyTurn()
    {        

        var skill = enemyUnit.Enemy.GetRandomSkill();
        var target = GetRandomTarget();
        if (Tutorial1 == true && Tutorial2 == false)
        {
            skill = enemyUnit.Enemy.Skills[0];
        }
        yield return PerformMove(enemyUnit, target, skill);

        if (Tutorial1Defend == false)
        {
            Tutorial1Defend = true;
            StartCoroutine(tutorial.Tutorial1Finish());
        }
        else if (Tutorial1 == true && Tutorial2 == false)
        {
            StartCoroutine(tutorial.Tutorial2Knock());
        }
        else
            if (state == FightState.Attack)
            StartCoroutine(PlayerTurn());
    }

    public IEnumerator PerformMove(FighterUnit attackUnit, FighterUnit targetUnit, Skill skill)
    {
        
        yield return dialogueBox.ScrollDialogue($"{attackUnit.Enemy.template.Name} used {skill.Skillt.Name}!");
        yield return new WaitForSeconds(1f);

        if (skill.Skillt.Category == SkillCategory.Status)
        {
            var change = skill.Skillt.Effects;

            if (change.Change != null)
            {
                if (skill.Skillt.Target == SkillTarget.Self)
                {
                    attackUnit.Enemy.ApplyChanges(change.Change);                                      
                }
                else if (skill.Skillt.Target == SkillTarget.Enemy || skill.Skillt.Target == SkillTarget.Ally)
                {
                    targetUnit.Enemy.ApplyChanges(change.Change);                   
                }
                else if (skill.Skillt.Target == SkillTarget.Party)
                {
                    foreach (var member in party)
                    {
                        member.Enemy.ApplyChanges(change.Change);
                        yield return StatChanges(member.Enemy);
                        yield return new WaitForSeconds(0.5f);
                    }                    
                }                
            }
        }
        else if (skill.Skillt.Category == SkillCategory.Weapon || skill.Skillt.Category == SkillCategory.Elementa)
        {
            var change = skill.Skillt.Effects;
            bool isFainted = targetUnit.Enemy.TakeDamage(skill, attackUnit.Enemy);
            attackUnit.Enemy.ApplyChanges(change.Change);            
        }
        else if (skill.Skillt.Category == SkillCategory.Healing)
        {
            if (skill.Skillt.Target == SkillTarget.Self)
            {
                attackUnit.Enemy.Heal(skill, attackUnit.Enemy);
                yield return dialogueBox.ScrollDialogue($"{attackUnit.Enemy.template.Name} was healed!");
            }
            else if (skill.Skillt.Target == SkillTarget.Ally)
            {
                targetUnit.Enemy.Heal(skill, attackUnit.Enemy);
                yield return dialogueBox.ScrollDialogue($"{targetUnit.Enemy.template.Name} was healed!");
            }
            else if (skill.Skillt.Target == SkillTarget.Party)
            {
                foreach (var member in party)
                {
                    member.Enemy.Heal(skill, attackUnit.Enemy);
                    yield return member.Hud.UpdateHP();
                }
                yield return dialogueBox.ScrollDialogue("party was healed!");
                yield return new WaitForSeconds(0.5f);                
            }
        }

        attackUnit.Enemy.UseStamina(skill);
        yield return targetUnit.Hud.UpdateHP();
        yield return attackUnit.Hud.UpdateHP();

        if (skill.Skillt.Category == SkillCategory.Weapon || skill.Skillt.Category == SkillCategory.Elementa)
        {
            if (targetUnit.Enemy.effectiveness == 2f)
            {
                yield return dialogueBox.ScrollDialogue($"{targetUnit.Enemy.template.Name} was weak to {skill.Skillt.Name}!");
                yield return new WaitForSeconds(1f);
            }
            else if (targetUnit.Enemy.effectiveness == 0.5f)
            {
                yield return dialogueBox.ScrollDialogue($"{targetUnit.Enemy.template.Name} resisted {skill.Skillt.Name}!");
                yield return new WaitForSeconds(1f);
            }
            else if (targetUnit.Enemy.effectiveness == 0f)
            {
                yield return dialogueBox.ScrollDialogue($"{targetUnit.Enemy.template.Name} is immune to {skill.Skillt.Name}!");
                yield return new WaitForSeconds(1f);
            }
        }

        yield return StatChanges(attackUnit.Enemy);
        yield return StatChanges(targetUnit.Enemy);

        if (targetUnit.Enemy.HP == 0)
        {
            yield return dialogueBox.ScrollDialogue($"{targetUnit.Enemy.template.Name} was defeated.");
            StartCoroutine(Checkpartydied(targetUnit));
        }        
    }

    IEnumerator StatChanges(Enemy enemy)
    {
        while (enemy.StatChanges.Count > 0)
        {
            var msg = enemy.StatChanges.Dequeue();
            yield return dialogueBox.ScrollDialogue(msg);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator Checkpartydied(FighterUnit knockedUnit)
    {
        if (knockedUnit.IsPartyUnit)
        {
            ++partyUnitsDead;
            party.Remove(knockedUnit);
            Debug.Log(partyUnitsDead);           
            if (partyUnitsDead == 3)
            {
                state = FightState.BattleOver;
                yield return dialogueBox.ScrollDialogue("Party was defeated.");
                yield return new WaitForSeconds(1f);
                BattleOver(false);
            }
        }
        else
        {
            state = FightState.BattleOver;
            if (Tutorial1 == false)
            {
                playerUnit1.Enemy.Exp += 6;
                playerUnit2.Enemy.Exp += 6;
                playerUnit3.Enemy.Exp += 6;
                yield return dialogueBox.ScrollDialogue($"Party gained 6 exp.");

                //level up
                foreach (var member in party)
                {
                    if (member.Enemy.LevelUp())
                    {
                        yield return dialogueBox.ScrollDialogue($"{member.Enemy.template.Name} gained a level!");
                        yield return new WaitForSeconds(0.5f);
                    }
                }

                Tutorial1 = true;
                StartCoroutine(tutorial.Tutorial1End());
            }
            else
            {
                //exp gain
                int expYield = knockedUnit.Enemy.template.ExpYield;
                int unitLevel = knockedUnit.Enemy.Lvl;
                int expGain = Mathf.FloorToInt((expYield / 20) * unitLevel);

                playerUnit1.Enemy.Exp += expGain;
                playerUnit2.Enemy.Exp += expGain;
                playerUnit3.Enemy.Exp += expGain;
                yield return dialogueBox.ScrollDialogue($"Party gained {expGain} exp.");

                //level up
                foreach (var member in party)
                {
                    if (member.Enemy.LevelUp())
                    {
                        yield return dialogueBox.ScrollDialogue($"{member.Enemy.template.Name} gained a level!");
                        yield return new WaitForSeconds(0.5f);
                    }
                }

                yield return new WaitForSeconds(1f);
                BattleOver(true);
            }            
        }        
    }

    public void TutorialEnd()
    {
        BattleOver(true);
    }

    public IEnumerator Running(float delay)
    {
        yield return new WaitForSeconds(delay);

        Buttons.gameObject.SetActive(false);

        yield return dialogueBox.ScrollDialogue("You ran from battle.");

        yield return new WaitForSeconds(1f);        
        mainCamera.gameObject.SetActive(true);
        battlecamera.gameObject.SetActive(true);
        gameObject.SetActive(false);
        BattleOver(true);
    }




    public void Attack()
    {
        Buttons.gameObject.SetActive(false);
        StartCoroutine(normalattack());
    }

    public void Skill()
    {
        Buttons.gameObject.SetActive(false);
        SkillsMenu.gameObject.SetActive(true);
        SkillsMenu.transform.GetChild(0).gameObject.SetActive(true);
        SkillsMenu.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void SkillAttacks1()
    {
        currentSkill = 0;

        if (party[activeMember].Enemy.Skills[currentSkill].Skillt.Target == SkillTarget.Ally)
        {
            SkillsMenu.transform.GetChild(0).gameObject.SetActive(false);
            SkillsMenu.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            SkillsMenu.gameObject.SetActive(false);
            StartCoroutine(skillAttack());
        }       
    }

    public void SkillAttacks2()
    {
        currentSkill = 1;


        if (party[activeMember].Enemy.Skills[currentSkill].Skillt.Target == SkillTarget.Ally)
        {
            SkillsMenu.transform.GetChild(0).gameObject.SetActive(false);
            SkillsMenu.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            SkillsMenu.gameObject.SetActive(false);
            StartCoroutine(skillAttack());
        }
    }

    public void SkillAttacks3()
    {
        currentSkill = 2;


        if (party[activeMember].Enemy.Skills[currentSkill].Skillt.Target == SkillTarget.Ally)
        {
            SkillsMenu.transform.GetChild(0).gameObject.SetActive(false);
            SkillsMenu.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            SkillsMenu.gameObject.SetActive(false);
            StartCoroutine(skillAttack());
        }
    }

    public void SkillAttacks4()
    {
        currentSkill = 3;


        if (party[activeMember].Enemy.Skills[currentSkill].Skillt.Target == SkillTarget.Ally)
        {
            SkillsMenu.transform.GetChild(0).gameObject.SetActive(false);
            SkillsMenu.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            SkillsMenu.gameObject.SetActive(false);
            StartCoroutine(skillAttack());
        }
    }

    public void SkillAttacks5()
    {
        currentSkill = 4;


        if (party[activeMember].Enemy.Skills[currentSkill].Skillt.Target == SkillTarget.Ally)
        {
            SkillsMenu.transform.GetChild(0).gameObject.SetActive(false);
            SkillsMenu.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            SkillsMenu.gameObject.SetActive(false);
            StartCoroutine(skillAttack());
        }
    }

    public void SkillClose()
    {
        Buttons.gameObject.SetActive(true);
        SkillsMenu.gameObject.SetActive(false);
    }

    public void Run()
    {
        StartCoroutine(Running(0.5f));
    }

    public void Defend()
    {
        party[activeMember].Enemy.IsDefending = true;
        party[activeMember].Enemy.Defending();
        Buttons.gameObject.SetActive(false);
        StartCoroutine(Defending());
    }

    public FighterUnit GetRandomTarget()
    {
        if (Tutorial1Defend == false)
        {
            return party[2];
        }
        else
        {
            int r = Random.Range(0, party.Count);
            return party[r];
        }           
    }

    public void Jasper()
    {
        Allytarget = playerUnit1;

        SkillsMenu.gameObject.SetActive(false);
        StartCoroutine(skillAttack());
    }

    public void Nathan()
    {
        Allytarget = playerUnit2;

        SkillsMenu.gameObject.SetActive(false);
        StartCoroutine(skillAttack());
    }

    public void Christina()
    {
        Allytarget = playerUnit3;

        SkillsMenu.gameObject.SetActive(false);
        StartCoroutine(skillAttack());
    }

    public void CloseTarget()
    {
        SkillsMenu.transform.GetChild(0).gameObject.SetActive(true);
        SkillsMenu.transform.GetChild(1).gameObject.SetActive(false);
    }
}
