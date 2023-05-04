using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveR : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rightPositonX = 5f;
    public float leftPositionX = 7f;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (transform.position.x >= rightPositonX && movingRight)
        {
            movingRight = false;
        }
        else if (transform.position.x <= -leftPositionX && !movingRight)
        {
            movingRight = true;
        }
    }
}
