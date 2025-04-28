using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class FightHUD : MonoBehaviour
{
    [SerializeField] TMP_Text name;
    [SerializeField] TMP_Text level;
    [SerializeField] Healthbar healthbar;
    [SerializeField] Healthbar staminaBar;

    Enemy _fighter;

    public void SetData(Enemy fighter)
    {
        _fighter = fighter;

        name.text = fighter.template.Name;
        level.text = "Lv " + fighter.Lvl;
        healthbar.SetHealth((float)fighter.HP / fighter.Maxhp);
        
        staminaBar.SetStamina((float)fighter.Stam / fighter.Maxstam);
    }

    public IEnumerator UpdateHP()
    {
        yield return healthbar.SetHealthSmooth((float)_fighter.HP / _fighter.Maxhp, (float)_fighter.Stam / _fighter.Maxstam);        
    }

    
}
