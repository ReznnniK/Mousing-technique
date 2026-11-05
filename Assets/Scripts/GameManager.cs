
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnInterval=1f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;
    int amount = 0;
    bool over;

    void Start()
    {
        over=false;
        scoreText.text=$"Score:{amount}";
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (!over)
        {

            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public void updateScore(int addScore)
    {
        if (!over)
        {
            amount+=addScore;
            scoreText.text=$"Score:{amount}";            
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);

        restartBtn.gameObject.SetActive(true);
       // StopAllCoroutines();
        over=true;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // amount=0;
        // updateScore(amount);
        // over=false;
       // StartCoroutine(SpawnObjects());

    }
}
