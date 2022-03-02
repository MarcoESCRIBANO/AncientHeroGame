using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealtBarHandler : MonoBehaviour
{
    private float currentHealth;
    [SerializeField]private Image healthBarre;
    [SerializeField] private int regenPerSecond;
    void Start()
    {
        currentHealth = 50f;
        healthBarre.fillAmount = currentHealth/100;
        StartCoroutine(HealtDuringTime());
    }
    public void removeHealth(int number)
    {
        currentHealth -= number;
        healthBarre.fillAmount = currentHealth / 100;
    }
    public float getHealth()
    {
        return currentHealth;
    }

    IEnumerator HealtDuringTime()
    {
        while (true)
        {
            if (currentHealth < 100)
            {
             
                currentHealth += regenPerSecond;
                healthBarre.fillAmount = currentHealth / 100f;
            }
            yield return new WaitForSeconds(.5f);
        }
        
    }
}
