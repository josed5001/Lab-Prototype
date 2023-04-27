using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject easyDifficulty;
    public GameObject mediumDifficulty;

    private float timeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        easyDiff();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time;

        if (timeElapsed > 10f)
        {
            
        }
    }

    void easyDiff()
    {
        Vector3 aSpawnPos = new Vector3(0, 0, 0);

        Instantiate(easyDifficulty, aSpawnPos, easyDifficulty.gameObject.transform.rotation);
    }
}
