using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    public bool PausedGame = false;
    
    // MainMenu MainMenuScript;

    // MainMenuScript = gameObject.GetComponent<MainMenu>();

    void Update() 
    {
         Debug.Log("update");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape");

            if (PausedGame)
            {
                Debug.Log("resume");
                Resume();
                
            }
            else
            {
                Debug.Log("pause");
                Pause();
                
            }
        }
    }
    public void Pause()
    {
        Debug.Log("inpause");
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        PausedGame = true;
    }
    public void Resume()
    {
        Debug.Log("inresume");
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        PausedGame = false;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        // MainMenuScript.PreviousScene();
        SceneManager.LoadScene("Options");
    }

}
