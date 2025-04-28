using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TypesUI : MonoBehaviour
{
    [SerializeField] Types fire;
    [SerializeField] Types water;
    [SerializeField] Types electric;
    [SerializeField] Types wind;
    [SerializeField] Types light;
    [SerializeField] Types dark;
    [SerializeField] Types dull;
    [SerializeField] Types stab;
    [SerializeField] Types slash;

    [SerializeField] TMP_Text firetext;
    [SerializeField] TMP_Text watertext;
    [SerializeField] TMP_Text electrictext;
    [SerializeField] TMP_Text windtext;
    [SerializeField] TMP_Text lighttext;
    [SerializeField] TMP_Text darktext;
    [SerializeField] TMP_Text dulltext;
    [SerializeField] TMP_Text stabtext;
    [SerializeField] TMP_Text slashtext;

    [SerializeField] CharacterMenuUI inventory;

    
    
    public void SetTypes(Enemy Active)
    {        
        
        //set fire affinity
        if (Active.Weaknesses.Contains(fire))
        {            
            firetext.text = ("!!");
        }
        else if (Active.Resistances.Contains(fire))
        {
            firetext.text = ("O");
        }
        else if (Active.Immunities.Contains(fire))
        {
            firetext.text = ("X");
        }
        else
        {
            firetext.text = ("-");
        }

        //set water affinity
        if (Active.Weaknesses.Contains(water))
        {
            watertext.text = ("!!");
        }
        else if (Active.Resistances.Contains(water))
        {
            watertext.text = ("O");
        }
        else if (Active.Immunities.Contains(water))
        {
            watertext.text = ("X");
        }
        else
        {
            watertext.text = ("-");
        }

        //set electric affinity
        if (Active.Weaknesses.Contains(electric))
        {
            electrictext.text = ("!!");
        }
        else if (Active.Resistances.Contains(electric))
        {
            electrictext.text = ("O");
        }
        else if (Active.Immunities.Contains(electric))
        {
            electrictext.text = ("X");
        }
        else
        {
            electrictext.text = ("-");
        }

        //set wind affinity
        if (Active.Weaknesses.Contains(wind))
        {
            windtext.text = ("!!");
        }
        else if (Active.Resistances.Contains(wind))
        {
            windtext.text = ("O");
        }
        else if (Active.Immunities.Contains(wind))
        {
            windtext.text = ("X");
        }
        else
        {
            windtext.text = ("-");
        }

        //set light affinity
        if (Active.Weaknesses.Contains(light))
        {
            lighttext.text = ("!!");
        }
        else if (Active.Resistances.Contains(light))
        {
            lighttext.text = ("O");
        }
        else if (Active.Immunities.Contains(light))
        {
            lighttext.text = ("X");
        }
        else
        {
            lighttext.text = ("-");
        }

        //set dark affinity
        if (Active.Weaknesses.Contains(dark))
        {
            darktext.text = ("!!");
        }
        else if (Active.Resistances.Contains(dark))
        {
            darktext.text = ("O");
        }
        else if (Active.Immunities.Contains(dark))
        {
            darktext.text = ("X");
        }
        else
        {
            darktext.text = ("-");
        }

        //set dull affinity
        if (Active.Weaknesses.Contains(dull))
        {
            dulltext.text = ("!!");
        }
        else if (Active.Resistances.Contains(dull))
        {
            dulltext.text = ("O");
        }
        else if (Active.Immunities.Contains(dull))
        {
            dulltext.text = ("X");
        }
        else
        {
            dulltext.text = ("-");
        }

        //set stab affinity
        if (Active.Weaknesses.Contains(stab))
        {
            stabtext.text = ("!!");
        }
        else if (Active.Resistances.Contains(stab))
        {
            stabtext.text = ("O");
        }
        else if (Active.Immunities.Contains(stab))
        {
            stabtext.text = ("X");
        }
        else
        {
            stabtext.text = ("-");
        }

        //set slash affinity
        if (Active.Weaknesses.Contains(slash))
        {
            slashtext.text = ("!!");
        }
        else if (Active.Resistances.Contains(slash))
        {
            slashtext.text = ("O");
        }
        else if (Active.Immunities.Contains(slash))
        {
            slashtext.text = ("X");
        }
        else
        {
            slashtext.text = ("-");
        }
    }



    





}
