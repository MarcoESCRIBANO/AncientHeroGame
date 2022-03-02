using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReceiveDamage : MonoBehaviour
{
    [SerializeField] private GameObject healtBar;


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        healtBar.GetComponent<HealtBarHandler>().removeHealth(10);
    }
}
