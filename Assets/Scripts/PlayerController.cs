using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private Animator animator;
    private SpriteRenderer sprite;

    private float directionX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 14f;

    [SerializeField] private LayerMask ground;

    private enum AnimationState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSound, deathSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown("w") && CanJump()) 
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        UpdateAnimation();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Dead();
        }
    }

    private void UpdateAnimation()
    {
        AnimationState state;

        if(directionX > 0f)
        {
            state = AnimationState.running;
            sprite.flipX = false;
        }
        else if(directionX < 0f) 
        {
            state = AnimationState.running;
            sprite.flipX = true;
        }
        else{
            state = AnimationState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = AnimationState.jumping;
        }
        else if(rb.velocity.y < -0.1f)
        {
            state = AnimationState.falling;
        }
        
        animator.SetInteger("state", (int) state);
    }

    private bool CanJump()
    {
        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }

    private void Dead() 
    {
        animator.SetTrigger("dead");
        deathSound.Play();
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
