using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class L3EnemyController : MonoBehaviour
{
    private Transform player;
    UnityEngine.AI.NavMeshAgent agent;
    Rigidbody2D rb;
    private float jumpSpeed = 11f;
    private float directionX;
    public float speed;
    private float enemyToPlayerDistanceX, enemyToPlayerDistanceY;
    private bool run;
    private Animator anim;
    private SecondKnifeController sk;

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
            anim.Play("L3Enemy_Run");
        else
            anim.Play("L3Enemy_Idle");

            EnemyDirection();
            enemyToPlayerDistanceX = Mathf.Abs(transform.position.x - player.position.x);
            enemyToPlayerDistanceY = Mathf.Abs(transform.position.y - player.position.y);
            if(enemyToPlayerDistanceX <= 7 && enemyToPlayerDistanceY <=1 ){
                run = true;
                rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
            }
            else{
                rb.velocity = new Vector2(0, 0);
                run = false;
            }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("knife"))
        {
            Destroy(gameObject);
        }
    }
    void EnemyDirection(){
        Vector3 thescale = this.transform.localScale;
        if(this.transform.position.x < this.player.position.x){
            thescale.x = Mathf.Abs(thescale.x) * -1;
            directionX = 1f;
        }
        else{
            thescale.x = Mathf.Abs(thescale.x);
            directionX = -1f;
        }
        this.transform.localScale = thescale;
    }
}
