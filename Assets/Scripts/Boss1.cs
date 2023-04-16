using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    [SerializeField] private AudioSource bossHit;
    private Animator animator;
    private SpriteRenderer sprite;
    public float speed;
    private Transform player;
    Rigidbody2D rb;
    private float directionX = 0f;
    private enum AnimationState { idle, running, stunned }
    private enum ActionState { idle, running, stunned }
    private ActionState actionState;
    int lives;
    public GameObject flag;

    // Start is called before the first frame update
    void Start()
    {
        flag.SetActive(false);
        lives = 3;
        actionState = ActionState.idle;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if(actionState == ActionState.idle){
                EnemyDirection();
                actionState = ActionState.running;
            }
            else if(actionState == ActionState.running){
                rb.velocity = new Vector2(directionX * speed, rb.velocity.y);
            }
            else if(actionState == ActionState.stunned){
                waiter();
                actionState = ActionState.idle;
            }        
        }
        UpdateAnimation();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("knife"))
        {
            bossHit.Play();
            lives = lives - 1;
            actionState = ActionState.stunned;
            if(lives == 0){
                Destroy(gameObject);
                flag.SetActive(true);
            } 
        }

        if (collision.gameObject.CompareTag("wall"))
        {
            Debug.Log("wall collision");
            actionState = ActionState.stunned;
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

    private void UpdateAnimation()
    {
        AnimationState state;

        if(directionX > 0f)
        {
            state = AnimationState.running;
            sprite.flipX = true;
        }
        else if(directionX < 0f) 
        {
            state = AnimationState.running;
            sprite.flipX = false;
        }
        else{
            state = AnimationState.idle;
        }
        animator.SetInteger("state", (int) state);
    }
}
