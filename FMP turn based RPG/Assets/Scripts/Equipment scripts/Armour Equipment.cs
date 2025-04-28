using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourEquipment : MonoBehaviour
{
    [SerializeField] public List<Armour> armourlist;


    [System.Serializable]
    public class OwnedArmour
    {
        [SerializeField] Armour armours;

        public Armour Armours { get { return armours; } }

    }
}
