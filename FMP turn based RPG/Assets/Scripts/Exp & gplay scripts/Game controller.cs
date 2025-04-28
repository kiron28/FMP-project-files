using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState { Exploration, Menu, Battle, Scene }

public class Gamecontroller : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera battlecamera;
    [SerializeField] GameObject Menu;    
    [SerializeField] PauseMenuUI pauseMenuUI;
    [SerializeField] GameObject chats;
    [SerializeField] Enemy tutorial1;
    [SerializeField] Enemy tutorial2;
    [SerializeField] Enemy goliath;
    [SerializeField] Party party;
    [SerializeField] MenuTutorial menut;

    public GameState state;
    public bool dialoging = false;
    public bool IsTutorial;

    private void Start()
    {
        playerController.Encounter += StartBattle;        
        battleSystem.BattleOver += EndBattle;
        pauseMenuUI.MenuClose += CloseMenu;
    }    

    void StartBattle()
    {
        state = GameState.Battle;
        StartCoroutine(DelayMain(0.5f));        
    }
    
    public void BossBattle()
    {
        state = GameState.Battle;

        battleSystem.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        battlecamera.gameObject.SetActive(true);
        goliath.Create();
        battleSystem.StartBattle(goliath);
    }
    
    public void StartTutorialBattle()
    {
        state = GameState.Battle;
        StartCoroutine(DelayTutorial(0.5f));
    }

    public void StartTutorialBattle2()
    {
        state = GameState.Battle;
        StartCoroutine(DelayTutorial2(0.5f));
    }

    void EndBattle(bool won)
    {
        if (won == true)
        {
            state = GameState.Exploration;
            party.HealPostFight();
            battleSystem.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
            battlecamera.gameObject.SetActive(false);
            Debug.Log("fight won");
            if (menut.MenuOpen == false)
            {
                StartCoroutine(menut.Tutorialmenu());
            }
        }
        else if (won == false)
        {
            SceneManager.LoadScene("Main menu");
            Debug.Log("fight lost");
        }

    }

    void OpenMenu()
    {
        state = GameState.Menu;
        StartCoroutine(DelayMenu(0.2f));
        Menu.gameObject.SetActive(true);
        Menu.transform.GetChild(0).gameObject.SetActive(true);
        Menu.transform.GetChild(1).gameObject.SetActive(false);
        Menu.transform.GetChild(2).gameObject.SetActive(false);
        Debug.Log("Game paused");
    }

    void CloseMenu()
    {
        state = GameState.Exploration;
        Menu.gameObject.SetActive(false);
        Debug.Log("Game unpaused");
    }
    



    private void Update()
    {        
        if (state == GameState.Exploration)
        {
            playerController.HandleUpdate();            

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsTutorial == false)
                    OpenMenu();

                if (menut.MenuOpen == false)
                {                    
                    StartCoroutine(menut.TutorialParty());
                }
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                StartTutorialBattle();
            }
        }
        else if (state == GameState.Battle)
        {
            
        }
        else if (state == GameState.Menu)
        {            

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseMenu();
            }
        }

        if (chats.gameObject.activeSelf == true)
        {
            Debug.Log("active");
            state = GameState.Scene;
            dialoging = true;
            if (menut.TutorialStart == false)
            {
                state = GameState.Exploration;
            }
        }
        if (dialoging == true)
        {
            if (chats.gameObject.activeSelf == false)
            {
                state = GameState.Exploration;
                dialoging = false;
            }
            else if (Menu.gameObject.activeSelf == false)
            {
                state = GameState.Exploration;
                chats.gameObject.SetActive(false);
                dialoging = false;
            }
        }
    }

    IEnumerator DelayMain(float delay)
    {
        yield return new WaitForSeconds(delay);
        battleSystem.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        battlecamera.gameObject.SetActive(true);

        var monster = FindObjectOfType<EncounterTables>().GetComponent<EncounterTables>().GetRandomMonster();

        battleSystem.StartBattle(monster);
    }

    IEnumerator DelayMenu(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    IEnumerator DelayTutorial(float delay)
    {
        yield return new WaitForSeconds(delay);
        battleSystem.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        battlecamera.gameObject.SetActive(true);

        tutorial1.Create();
        battleSystem.StartBattle(tutorial1);
    }

    IEnumerator DelayTutorial2(float delay)
    {
        yield return new WaitForSeconds(delay);
        battleSystem.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        battlecamera.gameObject.SetActive(true);

        tutorial2.Create();
        battleSystem.StartBattle(tutorial2);
    }
}