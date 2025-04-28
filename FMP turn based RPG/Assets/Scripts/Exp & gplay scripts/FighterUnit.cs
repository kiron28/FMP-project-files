using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FighterUnit : MonoBehaviour
{
    
    [SerializeField] FightHUD hud;
    
    [SerializeField] bool isPartyUnit;

    public bool IsPartyUnit {  get { return isPartyUnit; } }
    
    public FightHUD Hud { get { return hud; } }

    public Enemy Enemy {  get; set; }


    public void Setup(Enemy enemy)
    {
        Enemy = enemy;
        hud.SetData(Enemy);
        GetComponent<Image>().sprite = Enemy.template.Charactersprite;
        
    }
}
