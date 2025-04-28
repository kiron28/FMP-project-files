using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using TMPro;
using System;

public class ItemList : MonoBehaviour
{
    [SerializeField] List<TMP_Text> itemTexts;
    [SerializeField] List<Button> itemButtons;
    [SerializeField] WeaponEquipment inventoryW;
    [SerializeField] ElementaEquipment inventoryE;
    [SerializeField] ArmourEquipment inventoryA;

    public List<Button> ItemButtons {  get { return itemButtons; } }
    public int order = 0;

    public void SetWeaponNames(List<Weapons> weapons)
    {
        for (int i = 0; i < itemTexts.Count; i++)
        {
            
            if (i < weapons.Count)
            {
                itemTexts[i].text = weapons[i].Name;
                itemButtons[i].gameObject.SetActive(true);
                itemButtons[i].gameObject.GetComponent<Button>();
                //itemButtons[i].onClick.AddListener(() => { order = i; Debug.Log("Clicked"); });
            }
            else
            {
                itemTexts[i].text = "";
                itemButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetElementaNames(List<Elementa> elementa)
    {
        for (int i = 0; i < itemTexts.Count; i++)
        {
            if (i < elementa.Count)
            {
                itemTexts[i].text = elementa[i].Name;
                itemButtons[i].gameObject.SetActive(true);
            }
            else
            {
                itemTexts[i].text = "";
                itemButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetArmourNames(List<Armour> armour)
    {
        for (int i = 0; i < itemTexts.Count; i++)
        {
            if (i < armour.Count)
            {
                itemTexts[i].text = armour[i].Name;
                itemButtons[i].gameObject.SetActive(true);
            }
            else
            {
                itemTexts[i].text = "";
                itemButtons[i].gameObject.SetActive(false);
            }
        }
    }
    
    void Buttonvalue()
    {
        int number = 0;
        foreach (var button in itemButtons)
        {            
            button.onClick.AddListener(() => { order = number; Debug.Log("Clicked"); });
            number++;
        }
    }
}
