using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReceiveDamage : MonoBehaviour
{
    [SerializeField] private GameObject object2;
    private int health;
    void Start()
    {
        health = 100;
        Debug.Log("aled");
    }

    // Update is called once per frame
    void GetDamage(int num)
    {
        this.health -= num;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("getDamage");
        this.GetDamage(5);
        
    }
}
