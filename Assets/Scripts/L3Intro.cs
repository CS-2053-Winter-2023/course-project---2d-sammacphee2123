using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Intro : MonoBehaviour
{
    public GameObject Level3Intro;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Level3Intro.SetActive(false);
            Time.timeScale = 1;
        }   
    }
}
