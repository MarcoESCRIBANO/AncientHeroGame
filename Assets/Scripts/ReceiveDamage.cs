using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReceiveDamage : MonoBehaviour
{
    [SerializeField] private GameObject healtBar;
    
    private int health;
    void Start()
    {
        health = 100;
        Debug.Log("aled");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("receive");
        healtBar.GetComponent<HealtBarHandler>().removeHealth(10);
        


    }
}
