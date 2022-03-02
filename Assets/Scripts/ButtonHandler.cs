using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void changeScene(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void QuitGame()  
    {
        Debug.Log("test");
        Application.Quit();
    }
    // Update is called once per frame 
}
