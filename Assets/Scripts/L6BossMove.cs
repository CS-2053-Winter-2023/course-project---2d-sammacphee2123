using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class L6BossMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    private bool canSlow = true;
    public Image healthBar;
    private int HP = 10;
    public float moveRange = 5f;
    private Transform player;
    private bool rdMove = false;
    private bool movingUp = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float playerY = player.position.y;
        float newY = Mathf.MoveTowards(transform.position.y, playerY, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (Random.value < 0.02f)
        {
            movingUp = !movingUp;
        }
        float direction = movingUp ? 1f : -1f;
        float newHeight = Mathf.Clamp(transform.position.y + direction * moveRange * Time.deltaTime, playerY - moveRange, playerY + moveRange);
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        if (healthBar.fillAmount == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("knife"))
        {
            //HP -= 1;
            healthBar.fillAmount -= (float)(0.1);// (HP/10); 
            if (canSlow)
            {
                speed = 1f;
                canSlow = false;
                StartCoroutine(slowDown());
            }
            
        }

    }
    private IEnumerator slowDown()
    {
        yield return new WaitForSeconds(2f);
        canSlow = true;
        speed = 2f;
    }
}
