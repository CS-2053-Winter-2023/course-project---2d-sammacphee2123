using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6BossAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireInterval = 3f;

    private Transform playerTransform;
    private bool canFire = true;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (canFire)
        {
            FireBullet();
            canFire = false;
            StartCoroutine(Reload());
        }
    }

    private void FireBullet()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(1f, 0.3f, 0f), Quaternion.Euler(new Vector3(0, 0, angle)));
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(fireInterval);
        canFire = true;
    }
}
