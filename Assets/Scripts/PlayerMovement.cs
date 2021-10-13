using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    public VJMovement jsMovement;
    public VJRotation jsRotation;
    private Vector3 direction;
    private float xMin, xMax, yMin, yMax;

    void Start()
    {
        xMax = Screen.width - 0.5f;
        xMin = 0.5f;
        yMax = Screen.height - 0.5f;
        yMin = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        direction = jsMovement.InputDirection;

        if (direction.magnitude != 0)
        {
            transform.position += direction * moveSpeed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), 0f);
        }
    }
}
