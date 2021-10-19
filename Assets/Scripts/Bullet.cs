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

    void FixedUpdate()
    {
        rb.AddForce(transform.up * bulletSpeed);
    }
 
    public void Shoot()
    {
        float instX = spawn.transform.position.x;
        float instY = spawn.transform.position.y;
        newBullet = Instantiate(bullet, new Vector3(instX, instY, 0), transform.rotation);
    }
}
