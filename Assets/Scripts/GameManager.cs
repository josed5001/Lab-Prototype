using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] prefabDiff;

    private float timeElapsed = 0f;
    private float timeDelay = 10f;
    private float deleteDelay = 9.5f;
    private bool gameIsOn = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(prefabSpawn());
        InvokeRepeating("destroyFun", deleteDelay, deleteDelay);

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

   
    void destroyLevelWithTag(string tag)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject taggedObject in taggedObjects)
        {
            Destroy(taggedObject);
        }
    }

    void destroyFun()
    {
        destroyLevelWithTag("Level");
    }




    IEnumerator prefabSpawn()
    {
        int currentIndex = 0;

        while (currentIndex < prefabDiff.Length)
        {
            Instantiate(prefabDiff[currentIndex], transform.position, prefabDiff[currentIndex].gameObject.transform.rotation);
            currentIndex++;

            yield return new WaitForSeconds(timeDelay);
        }
    }
}
