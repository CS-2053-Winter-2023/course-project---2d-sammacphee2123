using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondKnifeController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;
    public GameObject knifePrefab;
    public GameObject knife;
    public GameObject Player;
    public Transform knifeTransform;
    private Animator playerAnimator;
    public bool hasKnife;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = Player.GetComponent<Animator>();
        rb = Player.GetComponent<Rigidbody2D>();
        sprite = Player.GetComponent<SpriteRenderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        hasKnife = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePosition - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (Input.GetMouseButtonDown(0) && hasKnife)
        {
            hasKnife = false;
            knife = Instantiate(knifePrefab, knifeTransform.position, Quaternion.identity);
            rb.gravityScale *= -1;
            sprite.flipY = !sprite.flipY;
        }
        if(Input.GetKeyDown("r"))
        {
            DestroyKnife();
        }
    }

    public Vector3 getKnifePosition()
    {
        if(knife != null)
        {
            return knife.transform.position;
        }
        return Player.transform.position;
    }

    public void DestroyKnife()
    {
        if (knife != null)
        {
            hasKnife = true;
            Destroy(knife);
        }
    }
}
