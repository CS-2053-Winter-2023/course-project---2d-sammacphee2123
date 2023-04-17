using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKnife : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;
    public GameObject knifePrefab;
    public GameObject knife;
    public GameObject Player;
    public Transform knifeTransform;
    private Animator playerAnimator;
    public bool hasKnife;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = Player.GetComponent<Animator>();
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

        if (Input.GetMouseButton(0) && hasKnife)
        {
            hasKnife = false;
            knife = Instantiate(knifePrefab, knifeTransform.position, Quaternion.identity);
        }
        if (Input.GetMouseButton(1) && !hasKnife)
        {
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            playerAnimator.SetTrigger("dissapear");
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
