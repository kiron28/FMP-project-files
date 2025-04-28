using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armour", menuName = "Equipment/Create new Armour")]

public class Armour : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite armoursprite;


    [SerializeField] int maxhp;
    [SerializeField] int atk;
    [SerializeField] int eleatk;
    [SerializeField] int def;
    [SerializeField] int eledef;
    [SerializeField] int agi;
    [SerializeField] int maxstam;

    [SerializeField] public List<Types> weakness;
    [SerializeField] public List<Types> resistance;
    [SerializeField] public List<Types> immuniy;





    public string Name { get { return name; } }

    public string Description { get { return description; } }

    public Sprite Armoursprite { get { return armoursprite; } }

    public int Maxhp { get { return maxhp; } }

    public int Atk { get { return atk; } }

    public int Eleatk { get { return eleatk; } }

    public int Def { get { return def; } }

    public int Eledef { get { return eledef; } }

    public int Agi { get { return agi; } }

    public int Maxstam { get { return maxstam; } }

    public List<Types> Weakness { get { return weakness; } }

    public List<Types> Resistance { get { return resistance; } }

    public List<Types> Immunity { get { return immuniy; } }
}

