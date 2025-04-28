using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponpickup : MonoBehaviour
{
    [SerializeField] Weapons item;
    [SerializeField] WeaponEquipment inv;
    [SerializeField] Canvas canvas;
    [SerializeField] WorldDialogue dialogue;


    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        inv.weaponlist.Add(item);
        
        canvas.gameObject.SetActive(true);
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(true);

        yield return dialogue.ScrollDialogue($"Obtained {item.Name}!");
        yield return new WaitForSeconds(1f);
        if (dialogue.firstitem == false)
        {
            yield return dialogue.ScrollDialogue("Red orbs found around the world will contain weapons for you to use. Keep exploring so that you can find more and obtain new ways to fight in battle. You can also find purple orbs with new elementa and orange orbs with armour.");
            yield return new WaitForSeconds(1.5f);
            dialogue.firstitem = true;
        }
        Destroy(gameObject);
        canvas.gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
    }

}
