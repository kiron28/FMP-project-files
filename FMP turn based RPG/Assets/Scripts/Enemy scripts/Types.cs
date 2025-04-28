using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Types")]
public class Types : ScriptableObject
{
    [SerializeField] Type type;
    
}
public enum Type
{
    None,
    Slash,
    Stab,
    Dull,
    Fire,
    Water,
    Electric,
    Wind,
    Light,
    Dark
}




