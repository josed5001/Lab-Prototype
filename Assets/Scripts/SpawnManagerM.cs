using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerM : MonoBehaviour
{

    public SpawnManager spawnScript1;
    // Start is called before the first frame update
    void Start()
    {
        spawnScript1 = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnScript1.ObSpawnChange == true)
        {
            spawnScript1.TurnOff();
        }
    }
}
