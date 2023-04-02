using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public GameObject story;
    public GameObject gameIntro;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowStory()
    {
        if(story.activeSelf == true)
            story.SetActive(false);
        else
            story.SetActive(true);
    }


    public void Introduce()
    {
        gameIntro.SetActive(true);

    }
    public void IntroduceClose()
    {
        gameIntro.SetActive(false);

    }
}
