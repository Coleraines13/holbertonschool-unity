using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LevelSelect(int level)
    {
        // PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(level);
    }
    public void Options()
    {
        // PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options"); ;
    }
    public void QuitGame()
    {
        //PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        Debug.Log("Exited");
        Application.Quit();
    }
    public void PreviousScene()
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
    }

}
