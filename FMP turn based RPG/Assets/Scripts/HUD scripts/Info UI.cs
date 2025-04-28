using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class InfoUI : MonoBehaviour
{
    [SerializeField] GameObject infotabs;
    [SerializeField] CharacterMenuUI inventory;
    [SerializeField] TMP_Text skillname;
    [SerializeField] TMP_Text skillDesc;
    [SerializeField] TMP_Text skillstam;

    int currentSkill;
    public Enemy Enemy { get; set; }

    public void SetDescription()
    {
        var Enemy = inventory.Active;
        var active = Enemy.Skills[currentSkill];


        skillname.text = active.Skillt.Name;
        skillDesc.text = active.Skillt.Description;
        skillstam.text = (active.Skillt.Stamina.ToString() + " Stamina");
    }











    public void StatsTab()
    {       
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);

        infotabs.transform.GetChild(0).gameObject.SetActive(false);
        infotabs.transform.GetChild(1).gameObject.SetActive(true);
        infotabs.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void SkillsTab()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);

        infotabs.transform.GetChild(0).gameObject.SetActive(true);
        infotabs.transform.GetChild(1).gameObject.SetActive(false);
        infotabs.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void TypesTab()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);

        infotabs.transform.GetChild(0).gameObject.SetActive(true);
        infotabs.transform.GetChild(1).gameObject.SetActive(true);
        infotabs.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void Skill1()
    {
        currentSkill = 0;

        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        SetDescription();

    }

    public void Skill2()
    {
        currentSkill = 1;

        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        SetDescription();

    }

    public void Skill3()
    {
        currentSkill = 2;

        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        SetDescription();

    }

    public void Skill4()
    {
        currentSkill = 3;

        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        SetDescription();

    }

    public void Skill5()
    {
        currentSkill = 4;

        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        SetDescription();

    }

    public void ExitDesc()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(false);
    }

}
