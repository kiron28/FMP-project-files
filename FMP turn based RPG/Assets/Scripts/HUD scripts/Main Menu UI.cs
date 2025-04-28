using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OptionsMenu;
    


    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial Level");
    }

    public void Options()
    {
        StartCoroutine(Delay(0.2f));
        MainMenu.gameObject.SetActive(false);        
        OptionsMenu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);        
    }
}
