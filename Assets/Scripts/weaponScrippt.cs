using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScrippt : MonoBehaviour
{
    [SerializeField] private GameObject particule;
    // Start is called before the first frame update
    void Start()
    {
        particule.transform.parent = this.transform;
        //particuleObject.desActive();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.position);
    }
}
