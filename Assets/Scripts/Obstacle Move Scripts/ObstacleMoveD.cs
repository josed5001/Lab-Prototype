using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveD : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float topPositionY = 15f;
    public float bottomPositionY = 3f;
    private bool movingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (transform.position.y >= topPositionY && movingUp)
        {
            movingUp = false;
        }
        else if (transform.position.y <= bottomPositionY && !movingUp)
        {
            movingUp = true;
        }
    }
}
