using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Pause = false;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("1");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (Pause == false)
                PauseGame();
            else
                Continue();
        }
            
    }

    public void PauseGame()
    {
        
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        Pause = true;
    }
    public void Continue()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        Pause = false;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
