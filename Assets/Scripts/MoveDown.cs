using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public float speed = 2.5f;
    private float zDestroy = -110.0f;

    private SpawnManager spawnScript;
    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        spawnScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnScript.ObSpawnChange == true)
        {
            speed = 10f;
        }

           

        objectRb.AddForce(Vector3.forward * -speed);


        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
