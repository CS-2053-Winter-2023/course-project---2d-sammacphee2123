using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapS : MonoBehaviour
{
    // Start is called before the first frame update
    private bool canFire;
    public GameObject bullet;
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            Vector3 offset = new Vector3(2f, 0f, 0f); 
            GameObject c = Instantiate(bullet, new Vector3(0f, 0f, 0f), Quaternion.AngleAxis(180, Vector2.left));
            c.GetComponent<BulletCode>().InitPosition(transform.position + offset,new Vector3(2f, 0f, 0f));
            canFire = false;
            StartCoroutine(PlayerCanFireAgain());
        }
    }
    IEnumerator PlayerCanFireAgain()
    {
        yield return new WaitForSecondsRealtime(3);
        canFire = true;
    }
}
