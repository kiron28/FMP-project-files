using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class PartySkills : MonoBehaviour
{
    [SerializeField] List<TMP_Text> skillTexts;
    [SerializeField] List<TMP_Text> skillStamTexts;
    [SerializeField] List<Button> SkillButtons;


    public void SetSkillNames(List<Skill> skills)
    {
        for (int i = 0; i < skillTexts.Count; i++)
        {
            if (i < skills.Count)
            {
                skillTexts[i].text = skills[i].Skillt.Name;
                SkillButtons[i].gameObject.SetActive(true);
            }
            else
            {
                skillTexts[i].text = "";
                SkillButtons[i].gameObject.SetActive(false);
            }
        }
    }



    public void SetSkillStamina(List<Skill> skillsStam)
    {
        for (int i = 0; i < skillTexts.Count; i++)
        {
            if (i < skillsStam.Count)
            {
                skillStamTexts[i].text = skillsStam[i].Skillt.Stamina.ToString();
            }
            else
            {
                skillStamTexts[i].text = "";
            }
        }
    }
}
