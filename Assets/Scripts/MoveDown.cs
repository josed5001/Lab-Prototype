using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    
    private float zDestroy = -110.0f;
    
    private float timeDelay = 14.5f;
    private GameDifficulty gameDifficulty;
    private SpawnManager spawnScript;
    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        gameDifficulty = GameObject.Find("GameDifficulty").GetComponent<GameDifficulty>();
        spawnScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        objectRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        objectRb.AddForce(Vector3.forward * -gameDifficulty.speed);


        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }

    
}
