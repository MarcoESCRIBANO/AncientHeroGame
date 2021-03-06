using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform parent;
    float h;
    float v;
    private float yaun = 0f;

    // Update is called once per frame
    void Update()
    {
        rotation();
    }

    private void rotation()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        yaun = parent.transform.eulerAngles.y;
        float varYaun = 0;
        float varYaunX = 0;
        float varYaunY = 0;
        
        if (h > 0)
        {
            varYaunY = 90;
        }
        else if (h < 0)
        {
            varYaunY = 270;
        }

        if (v > 0)
        {
            if (h > 0)
            {
                varYaunX = 0;
            }
            else if (h < 0)
            {
                varYaunX = 360;
            }
        }
        else if (v < 0)
        {
            varYaunX = 180;
        }

        if (h!=0 || v != 0)
        {
            varYaun = (varYaunY * Mathf.Abs(h) + varYaunX* Mathf.Abs(v)) / (Mathf.Abs(h) + Mathf.Abs(v));
        }
        transform.eulerAngles = new Vector3(0f, (yaun + varYaun)%360, 0f);
    }
}
