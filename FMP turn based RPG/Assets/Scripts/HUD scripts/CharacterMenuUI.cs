using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterMenuUI : MonoBehaviour
{
    [SerializeField] TMP_Text name;
    [SerializeField] TMP_Text level;
    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text stamina;
    [SerializeField] TMP_Text attack;
    [SerializeField] TMP_Text eleattack;
    [SerializeField] TMP_Text defence;
    [SerializeField] TMP_Text eledefence;
    [SerializeField] TMP_Text agility;
    [SerializeField] TMP_Text weapon;
    [SerializeField] TMP_Text elementa;
    [SerializeField] TMP_Text armour;
    [SerializeField] TMP_Text exp;    
    [SerializeField] PartySkills charskills;
    [SerializeField] Scrollbar expbar;
    [SerializeField] GameObject expSlidingArea;
    [SerializeField] Party party;
    [SerializeField] TypesUI types;

    

    public EnemyTemplate ActiveMember;
    public Enemy Active;
    public int member;


    public void Party()
    {
        var enemy = party.Partymembers[member];
        name.text = enemy.template.Name;
        level.text = "Lv " + enemy.Lvl;
        health.text = enemy.Maxhp.ToString();
        stamina.text = enemy.Maxstam.ToString();
        attack.text = enemy.Atk.ToString();
        eleattack.text = enemy.Eleatk.ToString();
        defence.text = enemy.Def.ToString();
        eledefence.text = enemy.Eledef.ToString();
        agility.text = enemy.Agi.ToString();
        weapon.text = enemy.template.weapon.Name;
        elementa.text = enemy.template.elementa.Name;
        armour.text = enemy.template.armour.Name;
        exp.text = ($"{enemy.Exp.ToString()}/{enemy.Expforlevel.ToString()}");
        expbar.size = ((float)enemy.Exp / enemy.Expforlevel);
        if (enemy.Exp == 0 )
        {
            expSlidingArea.gameObject.SetActive(false);
        }
        GetComponent<Image>().sprite = enemy.template.Charactersprite;
        charskills.SetSkillNames(enemy.Skills);
        charskills.SetSkillStamina(enemy.Skills);
        types.SetTypes(enemy);
        ActiveMember = enemy.template;
        Active = enemy;
    }



}
