using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOptionsUI : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OptionsMenu;    
    



    public void Exit()
    {
        Debug.Log("Clicked exit");
        StartCoroutine(Delay(0.2f));
        MainMenu.gameObject.SetActive(true);        
        OptionsMenu.gameObject.SetActive(false);
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
