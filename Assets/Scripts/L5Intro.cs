using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L5Intro : MonoBehaviour
{
    public GameObject Level5Intro;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Level5Intro.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
