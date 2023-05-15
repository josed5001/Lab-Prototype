using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateCamera());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator RotateCamera()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
