using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill 
{
    public Skilltemplate Skillt { get; set; }
    public int Stamina { get; set; }
    public Types type { get; set; }
    

    public Skill(Skilltemplate etemplate)
    {
        Skillt = etemplate;
        Stamina = etemplate.Stamina;        
        type = etemplate.SkillType;
    }

    public string Name { get { return Skillt.Name; } }
}
