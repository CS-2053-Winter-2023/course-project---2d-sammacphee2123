using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   /* // Start is called before the first frame update
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
        else if (collision.gameObject.CompareTag("knife"))
        {
            Destroy(gameObject);
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
    }*/
    public Transform player;
    UnityEngine.AI.NavMeshAgent agent;
    Rigidbody2D rb;
    private float jumpSpeed = 11f;
    private float directionX;
    public float speed;
    private float enemyToPlayerDistance;
    private bool run;
    private Animator anim;

    void Start(){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        run = false;
    }

    void Update(){
        if (run)
            anim.Play("Pink_Run");
        else
            anim.Play("Pink_Idle");

        if (player != null)
        {
            EnemyDirection();
            enemyToPlayerDistance = transform.position.x - player.position.x;
            if((enemyToPlayerDistance >= 7) || (enemyToPlayerDistance <= -7)){
                directionX = 1f;
                rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
            }
            //pathfinding
            else{
                agent.SetDestination(player.position);
            }
            run = true;
        }
        else
            run = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemySmallJump"){
            //rb.AddForce(Vector2.up * 350f);
            rb.velocity = new Vector2(1f, jumpSpeed);

        }
        else if (collision.gameObject.tag == "EnemyBigJump"){
            rb.AddForce(Vector2.up * 500);
        }
        else if (collision.gameObject.CompareTag("knife"))
        {
            Destroy(gameObject);
        }
    }
    void EnemyDirection(){
        Vector3 thescale = this.transform.localScale;
        if(this.transform.position.x < this.player.position.x){
            thescale.x = Mathf.Abs(thescale.x);
            directionX = 1f;
        }
        else{
            thescale.x = Mathf.Abs(thescale.x) * -1;
            directionX = -1f;
        }
        this.transform.localScale = thescale;
    }
}
