using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveU : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float topPositionY = 15f;
    public float bottomPositionY = 3f;
    private bool movingDown = true;

    void Update()
    {
        if (movingDown)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= bottomPositionY)
            {
                movingDown = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= topPositionY)
            {
                movingDown = true;
            }
        }
    }
}

