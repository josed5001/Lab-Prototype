using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour
{
    public float rotationSpeed = 25f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the object in the Z-axis at the specified speed
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
