using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBattle2 : MonoBehaviour
{
    [SerializeField] Gamecontroller Controller;

    bool startedtutorial = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (startedtutorial == false)
        {
            Debug.Log("collided");
            Controller.StartTutorialBattle2();
            startedtutorial = true;
        }
    }
}
