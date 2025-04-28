using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    [SerializeField] List<Enemy> partymembers;

    public List<Enemy> Partymembers { get { return partymembers; } }

    private void Start()
    {
        foreach (var member in  partymembers)
        {
            member.Create();
        }

    }

    public void HealPostFight()
    {
        foreach(var member in partymembers)
        {
            member.HP = member.Maxhp;
            member.Stam = member.Maxstam;
        }
    }

    public void UpdateAffinities()
    {
        foreach (var member in partymembers)
        {
            member.UpdateAffinities();
        }
    }   
}
