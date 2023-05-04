using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveL : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftPositionX = -7f;
    public float rightPositionX = 5f;
    private bool movingLeft = true;

    void Update()
    {
        if (movingLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftPositionX)
            {
                movingLeft = false;
            }
        }
        else
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightPositionX)
            {
                movingLeft = true;
            }
        }
    }

}
