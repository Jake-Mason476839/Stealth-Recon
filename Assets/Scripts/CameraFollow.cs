using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    void FixedUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, offset.z);
    }
}
