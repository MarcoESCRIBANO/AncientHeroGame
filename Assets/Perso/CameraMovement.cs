using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float pitch = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //rotation();
    }

    private void rotation()
    {
        //pitch += Input.GetAxis("Mouse Y");
        if (pitch < 50 && pitch > -60)
        {
            transform.eulerAngles = new Vector3(-pitch, transform.eulerAngles.y, 0f);
        }

    }
}
