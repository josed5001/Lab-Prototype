using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    
    public float obstacleSpawnTime = 3f;
    public float Value = 0.2f;
    private float timeDelay = 14.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("obSubtract", timeDelay, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    void obSubtract()
    {
    
        obstacleSpawnTime -= Value;
    }
   
}
