using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject newBullet;
    private Rigidbody2D rb;
    public GameObject bullet;
    public GameObject spawn;
    public float bulletSpeed = 500;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        Destroy(bullet, 3.0f);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.up * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstruction")
        {
            Destroy(bullet);
        }

        if (collision.tag == "enemy")
        {
            Destroy(bullet);
        }
    }

    public void OnPointerDown()
    {
        shoot();
    }
 
    public void Shoot()
    {
        float instX = spawn.transform.position.x;
        float instY = spawn.transform.position.y;
        newBullet = Instantiate(bullet, new Vector3(instX, instY, 0), transform.rotation);
    }
}
