using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Create new Skill")]


public class Skilltemplate : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] int power;
    [SerializeField] int stamina;
    [SerializeField] SkillCategory category;
    [SerializeField] Types skillType;
    [SerializeField] SkillEffects effects;
    [SerializeField] SkillTarget target;

    

    public string Name { get { return name; } }

    public string Description { get { return description; } }

    public int Power { get { return power; } }

    public int Stamina { get { return stamina; } }

    public Types SkillType { get { return skillType; } } 
    
    public SkillCategory Category { get { return category; } }

    public SkillEffects Effects { get { return effects; } }

    public SkillTarget Target { get { return target; } }
}

[System.Serializable]
public class SkillEffects
{
    [SerializeField] List<StatChanges> change;

    public List<StatChanges> Change {  get { return change; } }
}

[System.Serializable]
public class StatChanges
{
    public Stat stat;
    public int change;
}


public enum SkillCategory
{
    Weapon, Elementa, Status, Healing
}

public enum SkillTarget
{
    Enemy, Self, Party, Ally
}


