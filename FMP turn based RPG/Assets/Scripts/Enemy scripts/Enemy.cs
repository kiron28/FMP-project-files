using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   

public class Enemy
{
    [SerializeField] EnemyTemplate _template;
    [SerializeField] int lvl;

    public Enemy(EnemyTemplate etplte, int elvl)
    {
        _template = etplte;
        lvl = elvl;

        Create();
    }

    public EnemyTemplate template { get { return _template; }  }
    public int HP { get; set; }
    public int Stam { get; set; }
    public int Lvl { get { return lvl; } }

    public int Expforlevel { get; set; }
    public int Exp {  get; set; }

    public List<Skill> Skills { get; set; }
    public List<Types> Weaknesses { get; set; }
    public List<Types> Resistances { get; set; }
    public List<Types> Immunities { get; set; }
    public float effectiveness { get; set; }
    public Skill Attack { get; set; }

    public Dictionary<Stat, int> Stats { get; private set; }
    public Dictionary<Stat, int> StatChange { get; private set; }
    public Queue<string> StatChanges { get; set; } 

    public bool IsDefending = false;

    public void Create()
    {       
        Skills = new List<Skill>();
        foreach (var skill in template.LearnableSkill)
        {
            if (skill.Level <= Lvl)
                Skills.Add(new Skill(skill.SkillTemplate));
        }
        foreach (var skill in template.weapon.LearnableSkill)
        {
            if (skill.Level <= Lvl)
                Skills.Add(new Skill(skill.SkillTemplate));
        }
        foreach (var skill in template.elementa.LearnableSkill)
        {
            if (skill.Level <= Lvl)
                Skills.Add(new Skill(skill.SkillTemplate));
        }

        Weaknesses = new List<Types>();
        foreach (var type in template.Weakness)
        {
            Weaknesses.Add(type);
        }
        foreach (var type in template.armour.Weakness)
        {
            Weaknesses.Add(type);
        }

        Resistances = new List<Types>();
        foreach (var type in template.Resistance)
        {
            Resistances.Add(type);
        }
        foreach (var type in template.armour.Resistance)
        {
            Resistances.Add(type);
        }

        Immunities = new List<Types>();
        foreach (var type in template.Immunity)
        {
            Immunities.Add(type);
        }
        foreach (var type in template.armour.Immunity)
        {
            Immunities.Add(type);
        }

        CalculateExp();
      
        Attack = new Skill(template.BasicAttack);

        CalculateStat();
        HP = Maxhp;
        Stam = Maxstam;

        StatChanges = new Queue<string>();

        StatChange = new Dictionary<Stat, int>()
        {
            { Stat.Attack, 0 },
            { Stat.ElementaAttack, 0 },
            { Stat.Defence, 0 },
            { Stat.ElementaDefence, 0 },
            { Stat.Agility, 0 }
        };
    }

    void CalculateExp()
    {
        Expforlevel = Mathf.FloorToInt(3 * ((Lvl + 1) * (Lvl + 1) * (Lvl + 1) / 4));
    }

    void CalculateStat()
    {
        Stats = new Dictionary<Stat, int>();
        
        Stats.Add(Stat.Attack, Mathf.FloorToInt((template.Atk + (Random.Range(0.7f, 1f) * Lvl)) + template.weapon.Atk + template.elementa.Atk + template.armour.Atk));
        Stats.Add(Stat.ElementaAttack, Mathf.FloorToInt((template.Eleatk + (Random.Range(0.7f, 1f) * Lvl)) + template.weapon.Eleatk + template.elementa.Eleatk + template.armour.Eleatk));
        Stats.Add(Stat.Defence, Mathf.FloorToInt((template.Def + (Random.Range(0.7f, 1f) * Lvl) ) + template.weapon.Def + template.elementa.Def + template.armour.Def));
        Stats.Add(Stat.ElementaDefence, Mathf.FloorToInt((template.Eledef + (Random.Range(0.7f, 1f) * Lvl)) + template.weapon.Eledef + template.elementa.Eledef + template.armour.Eledef));
        Stats.Add(Stat.Agility, Mathf.FloorToInt((template.Agi + (Random.Range(0.7f, 1f) * Lvl)) + template.weapon.Agi + template.elementa.Agi + template.armour.Agi));

        Maxhp = Mathf.FloorToInt((template.Maxhp + (Random.Range(0.9f, 1.3f) * Lvl)) + template.weapon.Maxhp + template.elementa.Maxhp + template.armour.Maxhp);
        Maxstam = Mathf.FloorToInt((template.Maxstam + (Random.Range(1f, 1.3f) * Lvl)) + template.weapon.Maxstam + template.elementa.Maxstam + template.armour.Maxstam);
    }    

    public void UpdateAffinities()
    {
        Skills = new List<Skill>();
        foreach (var skill in template.weapon.LearnableSkill)
        {
            if (skill.Level <= Lvl)
                Skills.Add(new Skill(skill.SkillTemplate));
        }
        foreach (var skill in template.elementa.LearnableSkill)
        {
            if (skill.Level <= Lvl)
                Skills.Add(new Skill(skill.SkillTemplate));
        }

        
        foreach (var type in template.Weakness)
        {
            Weaknesses.Add(type);
        }
        foreach (var type in template.armour.Weakness)
        {
            Weaknesses.Add(type);
        }

        
        foreach (var type in template.Resistance)
        {
            Resistances.Add(type);
        }
        foreach (var type in template.armour.Resistance)
        {
            Resistances.Add(type);
        }

        
        foreach (var type in template.Immunity)
        {
            Immunities.Add(type);
        }
        foreach (var type in template.armour.Immunity)
        {
            Immunities.Add(type);
        }
    }


    



    int GetStat(Stat stat)
    {
        int statval = Stats[stat];

        int change = StatChange[stat];
        var changeValue = new float[] { 1f, 2f, 3f };

        if (change >= 0)        
            statval = Mathf.FloorToInt(statval * changeValue[change]);        
        else
            statval = Mathf.FloorToInt(statval / changeValue[-change]);

        return statval;
    }

    public void ApplyChanges(List<StatChanges> statchanges)
    {
        foreach (var statchange in statchanges)
        {
            var stat = statchange.stat;
            var change = statchange.change;

            StatChange[stat] = Mathf.Clamp(StatChange[stat] + change, -2, 2);

            if (change > 0)
                StatChanges.Enqueue($"{template.Name}'s {stat} was raised!");
            else
                StatChanges.Enqueue($"{template.Name}'s {stat} was lowered!");


            Debug.Log($"{stat} has been changed to {StatChange[stat]}. " + Atk);
        }
    }



    public int Atk {  get { return GetStat(Stat.Attack) + template.weapon.Atk + template.elementa.Atk + template.armour.Atk; } }

    public int Eleatk { get { return GetStat(Stat.ElementaAttack) + template.weapon.Eleatk + template.elementa.Eleatk + template.armour.Eleatk; } }

    public int Def { get { return GetStat(Stat.Defence) + template.weapon.Def + template.elementa.Def + template.armour.Def; } }

    public int Eledef { get { return GetStat(Stat.ElementaDefence) + template.weapon.Eledef + template.elementa.Eledef + template.armour.Eledef; } }

    public int Agi { get { return GetStat(Stat.Agility) + template.weapon.Agi + template.elementa.Agi + template.armour.Agi; } }

    public int Maxhp { get; private set; }

    public int Maxstam { get; private set; }

    

    


    public bool TakeDamage(Skill skill, Enemy attacker)
    {
        float typedamage = 1f;
        Debug.Log(typedamage);

        if (Weaknesses.Contains(skill.type))
        {
            typedamage = 2f;
            effectiveness = 2f;
            Debug.Log("Weak!! " + typedamage);
        }
        else if (Resistances.Contains(skill.type))
        {
            typedamage = 0.5f;
            effectiveness = 0.5f;
            Debug.Log("Resists!! " + typedamage);
        }
        else if (Immunities.Contains(skill.type))
        {
            typedamage = 0f;
            effectiveness = 0f;
            Debug.Log("Immune!! " + typedamage);
        }
        else
        {
            typedamage = 1f;
            Debug.Log(typedamage);
            effectiveness = 1f;
        }
                
        float modifiers = Random.Range(0.85f, 1f) * typedamage;
        float a = (2 * attacker.Lvl + 10) / 250f;
        if(skill.Skillt.Category == SkillCategory.Weapon)
        {
            float d = a * skill.Skillt.Power * ((float)attacker.Atk / Def) + 2;
            int damage = Mathf.FloorToInt(d * modifiers);

            if (damage < 0) damage = 0;

            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
                return true;
            }
            Debug.Log("Used Weapon");
            Debug.Log($"Attack did {damage} damage");
            typedamage = 1f;
            return false;
        }
        else if (skill.Skillt.Category == SkillCategory.Elementa)
        {
            float d = a * skill.Skillt.Power * ((float)attacker.Eleatk / Eledef) + 2;
            int damage = Mathf.FloorToInt(d * modifiers);

            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
                return true;
            }
            Debug.Log("Used Elementa");
            typedamage = 1f;
            return false;
        }
        else
        {
            return false;
        }

    }

    public void Heal(Skill skill, Enemy attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = ((skill.Skillt.Power / 100) * Maxhp) + attacker.Eleatk / 2;
        int heal = Mathf.FloorToInt(a * modifiers);

        HP += heal;
        if (HP > Maxhp)
        {
            HP = Maxhp;
        }
        Debug.Log("Heal amount " + heal);
    }

    public void UseStamina(Skill skill)
    {
        Stam -= skill.Skillt.Stamina;
        if (Stam < 0)
        {
            Stam = 0;            
        }      
    }

    public Skill GetRandomSkill()
    {
        int r = Random.Range(0, Skills.Count);
        return Skills[r];
    }

    public bool LevelUp()
    {
        int leftoverExp = 0;

        if (Exp >= Expforlevel)
        {
            ++lvl;
            leftoverExp = Exp - Expforlevel;
            Exp = leftoverExp;
            CalculateStat();
            UpdateAffinities();
            CalculateExp();
            if (Exp >= Expforlevel)
                LevelUp();
            return true;
        }

        return false;
    }

    public void Defending()
    {
        Debug.Log($"{Stats[Stat.Defence]}");


        if (IsDefending == true)
        {
            Stats[Stat.Defence] = Stats[Stat.Defence] * 3;
            Debug.Log($"{Stats[Stat.Defence]}");
        }
        else if (IsDefending == false)
        {
            Stats[Stat.Defence] = Stats[Stat.Defence] / 3;
            Debug.Log($"{Stats[Stat.Defence]}");
        }
    }

    public void StaminaRegen()
    {
        Stam = Stam + (Maxstam / 10);
        if (Stam >= Maxstam)
        {
            Stam = Maxstam;
        }
    }
}
