using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject powerUp;

    private float zObstacleSpawn = 12.0f;
    private float xSpawnRange = -1.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void SpawnObstacle()
    {
        Vector3 SpawnPos = new Vector3(xSpawnRange, ySpawn, zObstacleSpawn);
        int RandomIndex = Random.Range(0, obstacles.Length);
        
        Instantiate(obstacles[RandomIndex], SpawnPos, obstacles[RandomIndex].gameObject.transform.rotation);
    }
}
