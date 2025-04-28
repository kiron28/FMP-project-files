using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create new Enemy")]

public class EnemyTemplate : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite charactersprite;

    [SerializeField] int maxhp;
    [SerializeField] int atk;
    [SerializeField] int eleatk;
    [SerializeField] int def;
    [SerializeField] int eledef;
    [SerializeField] int agi;
    [SerializeField] int maxstam;

    [SerializeField] int expYield;

    [SerializeField] Skilltemplate basicAttack;

    [SerializeField] public Weapons weapon;
    [SerializeField] public Elementa elementa;
    [SerializeField] public Armour armour;

    [SerializeField] List<LearnedSkill> learnableSkill;

    [SerializeField] public List<Types> weakness;
    [SerializeField] public List<Types> resistance;
    [SerializeField] public List<Types> immunity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Debug.Log(weakness);
        }
    }

    [System.Serializable]
    public class LearnedSkill
    {
        [SerializeField] Skilltemplate skillTemplate;
        [SerializeField] int level;

        public Skilltemplate SkillTemplate { get { return skillTemplate; } }
        
        public int Level { get { return level; } }
    }

    
    

    public string Name { get { return name; } }

    public string Description { get { return description; } }

    public Sprite Charactersprite { get { return charactersprite; } }

    public int Maxhp { get { return maxhp; } }

    public int Atk { get { return atk; } }

    public int Eleatk { get { return eleatk; } }

    public int Def { get { return def; } }

    public int Eledef { get { return eledef; } }

    public int Agi { get { return agi; } }

    public int Maxstam { get { return maxstam; } }

    public int ExpYield { get { return expYield; } }

    public Skilltemplate BasicAttack { get { return basicAttack; } }

    public List<LearnedSkill> LearnableSkill { get { return learnableSkill; } }

    public List<Types> Weakness { get { return weakness; } }

    public List<Types> Resistance { get { return resistance; } }

    public List<Types> Immunity { get { return immunity; } }

    public Weapons Weapon { get { return weapon; } }
 
}

public enum Stat
{
    Attack,
    ElementaAttack,
    Defence,
    ElementaDefence,
    Agility
}

