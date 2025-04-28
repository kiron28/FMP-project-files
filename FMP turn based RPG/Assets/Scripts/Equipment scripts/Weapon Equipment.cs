using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipment : MonoBehaviour
{
    [SerializeField] public List<Weapons> weaponlist;
    

    [System.Serializable]
    public class OwnedWeapon
    {
        [SerializeField] Weapons weapon;        

        public Weapons Weapon { get { return weapon; } }
        
    }
}
