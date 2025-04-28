using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PartySelectUI : MonoBehaviour
{
    [SerializeField] TMP_Text name;
    [SerializeField] TMP_Text level;
    [SerializeField] TMP_Text health;
    [SerializeField] TMP_Text stamina;
    [SerializeField] Party party;

    public int member;
    
    
    


    public void Update()
    {
        var current = party.Partymembers[member];
        name.text = current.template.Name;
        level.text = "Lv " + current.Lvl;
        health.text = current.Maxhp.ToString();
        stamina.text = current.Maxstam.ToString();
        GetComponent<Image>().sprite = current.template.Charactersprite;
    }


}
