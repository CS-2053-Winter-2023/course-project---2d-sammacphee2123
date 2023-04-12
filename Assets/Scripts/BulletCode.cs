using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity != null)
            transform.Translate(velocity * Time.deltaTime * speed);

    }
    public void InitPosition(Vector3 p, Vector3 v)
    {
        transform.position = p;
        velocity = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            return;
        if(collision.gameObject.CompareTag("thirdKnife"))
        {
            velocity = -velocity;
            return;
        }
        Destroy(gameObject);
    }
}
