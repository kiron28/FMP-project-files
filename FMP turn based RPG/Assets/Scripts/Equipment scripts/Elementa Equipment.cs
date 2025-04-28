using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementaEquipment : MonoBehaviour
{
    [SerializeField] public List<Elementa> elementalist;


    [System.Serializable]
    public class OwnedElementa
    {
        [SerializeField] Elementa element;

        public Elementa Element { get { return element; } }

    }
}
