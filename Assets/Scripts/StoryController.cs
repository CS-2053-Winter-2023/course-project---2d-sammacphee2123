using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public TextMeshProUGUI storyText, buttonText;
    public string[] story = {"As the government's most esteemed ninja, you have been tasked to track down the whereabouts of the three mob bosses who stole our army's weapons. Your mission is to find them and take the weapons back. ", "The only weapon that was left unstolen was the powerful teleporting knife! Click on the screen to throw a knife in that direction, and right click to teleport to the knife.", "If you need your knife to return to you, press 'R'. You can move with 'A' and 'D' and jump with 'W'.", "Use the knife effectively to reach the end of the level and find the boss's lair, but watch out for enemies and traps. good luck Ninja Frog!"};
    public int storyIndex;
    // Start is called before the first frame update
    void Start()
    {
        storyIndex = 0;
        storyText.text = story[storyIndex];
        buttonText.text = "Next ->";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextText()
    {
        storyIndex++;
        if(storyIndex > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(storyIndex > 2)
        {
            buttonText.text = "Start!";
            storyText.text = story[storyIndex];
        }
        else
        {
            storyText.text = story[storyIndex];
        }
    }
}
