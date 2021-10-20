using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    public GameObject deadEnemy;
    private GameObject deadEnemyInstance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Destroy(enemy);

            float instX = spawn.transform.position.x;
            float instY = spawn.transform.position.y;
            deadEnemyInstance = Instantiate(deadEnemy, new Vector3(instX, instY, 0), transform.rotation);
        }
    }
}
