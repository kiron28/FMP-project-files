using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Elementa", menuName = "Equipment/Create new Elementa")]

public class Elementa : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite elementasprite;

    [SerializeField] Types elementaType;

    [SerializeField] int maxhp;
    [SerializeField] int atk;
    [SerializeField] int eleatk;
    [SerializeField] int def;
    [SerializeField] int eledef;
    [SerializeField] int agi;
    [SerializeField] int maxstam;

    [SerializeField] List<LearnedSkill> learnableSkill;




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

    public Sprite Elementasprite { get { return elementasprite; } }

    public Types ElementaType { get { return elementaType; } }

    public int Maxhp { get { return maxhp; } }

    public int Atk { get { return atk; } }

    public int Eleatk { get { return eleatk; } }

    public int Def { get { return def; } }

    public int Eledef { get { return eledef; } }

    public int Agi { get { return agi; } }

    public int Maxstam { get { return maxstam; } }

    public List<LearnedSkill> LearnableSkill { get { return learnableSkill; } }
}
