using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject skelettonObject;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        healthBar.GetComponent<HealtBarHandler>().removeHealth(10);
        skelettonObject.GetComponent<SkeletonController>().removeHealth(10);
    }
}
