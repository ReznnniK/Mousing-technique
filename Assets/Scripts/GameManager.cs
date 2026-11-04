
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnInterval=1f;
    public TextMeshProUGUI scoreText;
    int amount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text=$"Score:{amount}";
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

    public void updateScore(int addScore)
    {
        amount+=addScore;
        scoreText.text=$"Score:{amount}";
    }
}
