using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void changeScene(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void QuitGame()  
    {
        Application.Quit();
    }
}
