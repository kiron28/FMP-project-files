using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class PauseMenuUI : MonoBehaviour
{

    [SerializeField] CharacterMenuUI inventory;
    [SerializeField] GameObject Equipment;    
    [SerializeField] GameObject Items;
    [SerializeField] ElementaEquipment inventoryE;
    [SerializeField] WeaponEquipment inventoryW;
    [SerializeField] ArmourEquipment inventoryA;
    [SerializeField] ItemList maininv;
    [SerializeField] MenuTutorial menut;
    [SerializeField] EnemyTemplate party1;
    [SerializeField] EnemyTemplate party2;
    [SerializeField] EnemyTemplate party3;
    [SerializeField] Button nathan;
    [SerializeField] Button christina;

    [SerializeField] GameObject info;
    [SerializeField] GameObject Tab;


    public int MenuType;
    public event Action MenuClose;



    // Main menu buttons 

    public void Party()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        if (menut.MenuOpen == false)
            menut.MenuOpen = true;
        if (menut.partyopen == false)
        {
            StartCoroutine(menut.TutorialChar());
            nathan.interactable = false;
            christina.interactable = false;
        }           
        else
        {
            nathan.interactable = true;
            christina.interactable = true;
        }
    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ExitMenu()
    {        
        Debug.Log("closed menu");
        MenuClose();
    }

    //Party Select buttons

    public void ClosePartySelect()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Party1Select()
    {
        inventory.member = 0;
        inventory.Party();
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        info.transform.GetChild(0).gameObject.SetActive(true);
        info.transform.GetChild(1).gameObject.SetActive(false);
        info.transform.GetChild(2).gameObject.SetActive(false);
        info.transform.GetChild(3).gameObject.SetActive(false);
        Equipment.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        Tab.gameObject.SetActive(true);
        Tab.transform.GetChild(0).gameObject.SetActive(false);
        Tab.transform.GetChild(1).gameObject.SetActive(true);
        Tab.transform.GetChild(2).gameObject.SetActive(true);
        Items.gameObject.SetActive(false);
        Debug.Log("clicked");
        if (menut.partyopen == false)
        {
            menut.partyopen = true;
            StartCoroutine(menut.TutorialInv());
        }
    }

    public void Party2Select()
    {
        inventory.member = 1;
        inventory.Party();
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        info.transform.GetChild(0).gameObject.SetActive(true);
        info.transform.GetChild(1).gameObject.SetActive(false);
        info.transform.GetChild(2).gameObject.SetActive(false);
        info.transform.GetChild(3).gameObject.SetActive(false);
        Tab.transform.GetChild(0).gameObject.SetActive(false);
        Tab.transform.GetChild(1).gameObject.SetActive(true);
        Tab.transform.GetChild(2).gameObject.SetActive(true);
        Equipment.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        Tab.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);
        Debug.Log("clicked");
    }

    public void Party3Select()
    {
        inventory.member = 2;
        inventory.Party();
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        info.transform.GetChild(0).gameObject.SetActive(true);
        info.transform.GetChild(1).gameObject.SetActive(false);
        info.transform.GetChild(2).gameObject.SetActive(false);
        info.transform.GetChild(3).gameObject.SetActive(false);
        Tab.transform.GetChild(0).gameObject.SetActive(false);
        Tab.transform.GetChild(1).gameObject.SetActive(true);
        Tab.transform.GetChild(2).gameObject.SetActive(true);
        Equipment.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        Tab.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);
        Debug.Log("clicked");
    }

    public void CloseInventory()
    {
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    //Inventory buttons

    public void Weapon()
    {
        maininv.SetWeaponNames(inventoryW.weaponlist);
        Equipment.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        Tab.gameObject.SetActive(false);
        Items.gameObject.SetActive(true);
        MenuType = 1;
    }

    public void Elementa()
    {
        maininv.SetElementaNames(inventoryE.elementalist);
        Equipment.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        Tab.gameObject.SetActive(false);
        Items.gameObject.SetActive(true);
        MenuType = 2;
    }

    public void Armour()
    {
        maininv.SetArmourNames(inventoryA.armourlist);
        Equipment.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        Tab.gameObject.SetActive(false);
        Items.gameObject.SetActive(true);
        MenuType = 3;
    }

    public void CloseItems()
    {
        Equipment.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        Tab.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);
    }    
}
