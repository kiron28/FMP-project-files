using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leavetutorial : MonoBehaviour
{
    public bool DoneTutorial = false;

    void OnTriggerEnter2D(Collider2D other)
    {        
       if (DoneTutorial == true)
        SceneManager.LoadScene("Main Level");                       
    }
}
