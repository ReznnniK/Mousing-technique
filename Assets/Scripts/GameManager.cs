
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnInterval=1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {

            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
            
        }
    }
}
