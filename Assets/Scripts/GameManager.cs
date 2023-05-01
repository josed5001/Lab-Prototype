using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] prefabDiff;

    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time;

        if (timeElapsed > 10f)
        {
            destroyLevelWithTag("Level");

        }

    }

   
    void destroyLevelWithTag(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject taggedObject in taggedObjects)
        {
            Destroy(taggedObject);
        }
    }

    IEnumerator prefabSpawn()
    {
        float spawnDelay = 1.0f;
        int currentIndex = 0;

        while (currentIndex < prefabDiff.Length)
        {
            Instantiate(prefabDiff[currentIndex], transform.position, prefabDiff[currentIndex].gameObject.transform.rotation);
            currentIndex++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
