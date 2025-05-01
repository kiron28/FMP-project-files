using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemSelect : MonoBehaviour
{
    [SerializeField] GameObject Equipment;
    [SerializeField] GameObject Stats;
    [SerializeField] GameObject Items;
    [SerializeField] GameObject tabs;

    [SerializeField] CharacterMenuUI menu;
    [SerializeField] ItemList items;

    [SerializeField] WeaponEquipment inventoryW;
    [SerializeField] ElementaEquipment inventoryE;
    [SerializeField] ArmourEquipment inventoryA;

    [SerializeField] TMP_Text weapon;
    [SerializeField] TMP_Text elementa;
    [SerializeField] TMP_Text armour;

    [SerializeField] PauseMenuUI pause;

    [SerializeField] Party party;

    [SerializeField] Armour noneA;
    [SerializeField] Weapons noneW;
    [SerializeField] Elementa noneE;

    [SerializeField] MenuTutorial menut;

    Armour equippedA;
    Armour removedA;

    Weapons equippedW;
    Weapons removedW;

    Elementa equippedE;
    Elementa removedE;

    public void Item1()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[0];
            equippedW = menu.ActiveMember.weapon;
            
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[0];
            equippedE = menu.ActiveMember.elementa;
            
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[0];
            equippedA = menu.ActiveMember.armour;
            
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item()
    {

        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[1];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[1];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            menu.Party();
        }
        if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[1];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item2()
    {                
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[1];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }            
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();            
            menu.Party();            
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[1];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[1];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        if (menut.itemequip == false)
        {
            menut.TutorialpreEquip();
        }
        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);
    }

    public void Item3()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[2];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[2];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[2];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);
    }

    public void Item4()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[3];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[3];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[3];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item5()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[4];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[4];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[4];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item6()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[5];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[5];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[5];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item7()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[6];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[6];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[6];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item8()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[7];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[7];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[7];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item9()
    {
        if(pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[8];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[8];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[8];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }

    public void Item10()
    {
        if (pause.MenuType == 1)
        {
            removedW = menu.ActiveMember.weapon;
            menu.ActiveMember.weapon = inventoryW.weaponlist[9];
            equippedW = menu.ActiveMember.weapon;
            inventoryW.weaponlist.Remove(equippedW);
            if (removedW != noneW)
            {
                inventoryW.weaponlist.Add(removedW);
            }
            weapon.text = menu.ActiveMember.weapon.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 2)
        {
            removedE = menu.ActiveMember.elementa;
            menu.ActiveMember.elementa = inventoryE.elementalist[9];
            equippedE = menu.ActiveMember.elementa;
            inventoryE.elementalist.Remove(equippedE);
            if (removedE != noneE)
            {
                inventoryE.elementalist.Add(removedE);
            }
            elementa.text = menu.ActiveMember.elementa.Name;
            party.UpdateAffinities();
            menu.Party();
        }
        else if (pause.MenuType == 3)
        {
            removedA = menu.ActiveMember.armour;
            menu.ActiveMember.armour = inventoryA.armourlist[9];
            equippedA = menu.ActiveMember.armour;
            inventoryA.armourlist.Remove(equippedA);
            if (removedA != noneA)
            {
                inventoryA.armourlist.Add(removedA);
            }
            armour.text = menu.ActiveMember.armour.Name;
            party.UpdateAffinities();
            menu.Party();
        }

        Equipment.gameObject.SetActive(true);
        Stats.gameObject.SetActive(true);
        tabs.gameObject.SetActive(true);
        Items.gameObject.SetActive(false);

    }
}
