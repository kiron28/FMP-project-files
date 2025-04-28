using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
   [SerializeField] Scrollbar healthbar;
   [SerializeField] Scrollbar staminabar;
   [SerializeField] GameObject HealthSlidingArea;
   [SerializeField] GameObject StamSlidingArea;


    public float Health;
    public float Stamina;
   

    public void SetHealth(float healthnormalized)
    {
        healthbar.size = healthnormalized;
        Health = healthnormalized;
        if (Health > 0)
        {
            HealthSlidingArea.gameObject.SetActive(true);
        }
    }

    public void SetStamina(float stamNormalised)
    {
        staminabar.size = stamNormalised;
        Stamina = stamNormalised;
        if (Stamina > 0)
        {
            StamSlidingArea.gameObject.SetActive(true);
        }
    }

    public IEnumerator SetHealthSmooth(float newHealth, float newStam)
    {
        float curHealth = healthbar.size;
        float changeHealth = curHealth - newHealth;

        while (curHealth - newHealth > Mathf.Epsilon)
        {
            curHealth -= changeHealth * (2*Time.deltaTime);
            healthbar.size = curHealth;
            
            yield return null;
        }
        healthbar.size = newHealth;
        if (newHealth == 0)
        {
            HealthSlidingArea.gameObject.SetActive(false);
        }

        float curStam = staminabar.size;
        float changeStam = curStam - newStam;

        while (curStam - newStam > Mathf.Epsilon)
        {
            curStam -= changeStam * (2*Time.deltaTime);
            staminabar.size = curStam;

            yield return null;
        }
        staminabar.size = newStam;
        if (newStam == 0)
        {
            StamSlidingArea.gameObject.SetActive(false);
        }
    }

   

}
