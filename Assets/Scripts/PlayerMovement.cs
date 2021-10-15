using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public VJMovement jsMovement;
    public VJRotation jsRotation;
    private Vector3 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        direction = jsMovement.InputDirection;

        if (direction.magnitude != 0)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("vertical");
            float moveBy = x * moveSpeed;
            float move = y * moveSpeed;
            rb.velocity = new Vector3(moveBy, move, rb.velocity.z);
        }
    }
}
