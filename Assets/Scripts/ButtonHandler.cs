using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(string SceneToLoad)
    {
        Debug.Log(SceneToLoad);
        SceneManager.LoadScene(SceneToLoad);
    }
    // Update is called once per frame 
}
