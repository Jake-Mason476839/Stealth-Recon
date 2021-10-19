using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public VJMovement jsMovement;
    public VJRotation jsRotation;
    private Vector3 direction;
    private Vector3 rotation;
    private float xMin,xMax,yMin,yMax;
    public bool flipRot = true;
    public Transform rotationTarget;

    void Start()
    {
        xMax = Screen.width - 5;
        xMin = 5; 
        yMax = Screen.height - 5;
        yMin = 5;
    }


    void FixedUpdate()
    {
        direction = jsMovement.inputDirection;
        rotation = jsRotation.inputDirection;

        if (direction.magnitude != 0)
        {
            transform.position += direction * moveSpeed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,xMin,xMax),Mathf.Clamp(transform.position.y,yMin,yMax),0f);
        }

        if (rotation.magnitude != 0)
        {
            float horizontal = rotation.x;
            float vertical = rotation.y;

            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            angle = flipRot ? -angle : angle;

            rotationTarget.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
    }
}
