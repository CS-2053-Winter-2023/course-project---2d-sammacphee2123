using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool run;
    public float speed;
    private Transform player;
    Rigidbody2D rb;
    private float directionX = 0f;


    void Start()
    {
        anim = GetComponent<Animator>();
        run = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
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
            EnemyDirection();
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            rb.velocity = new Vector2(directionX * speed, rb.velocity.y);

            run = true;
        }
        else
            run = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemySmallJump"){
            rb.AddForce(Vector2.up * 350f);
        }
        else if (collision.gameObject.tag == "EnemyBigJump"){
            rb.AddForce(Vector2.up * 500);
        }
    }

    void EnemyDirection(){
        if(this.transform.position.x < this.player.position.x){
            Vector3 thescale = this.transform.localScale;
            this.transform.localScale = thescale;
            directionX = 1f;
        }
        else{
            directionX = -1f;
        }
    }
}
