using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pink : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    private bool run;
    public float speed;
    private Transform player;

    void Start()
    {
        anim = GetComponent<Animator>();
        run = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
            anim.Play("Pink_Run");
        else
            anim.Play("Pink_Idle");
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            run = true;
        }
        else
            run = false;
    }
}
