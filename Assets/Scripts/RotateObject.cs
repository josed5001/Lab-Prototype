using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 50f; // Speed of rotation around all axes

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around all axes at the specified speed
        transform.Rotate(rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime);
    }
}
