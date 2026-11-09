
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
    public TextMeshProUGUI title;
    public Button restartBtn;
    public List<Button> diffBtns;
    float levelSpeed;
    int amount = 0;
    bool over;

    void Start()
    {
        over=false;
        scoreText.text=$"Score:{amount}";

    }

    IEnumerator SpawnObjects(float flySpeed)
    {
        while (!over)
        {

            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0,targets.Count);
            levelSpeed=flySpeed;
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

    public void StartSpawnWithDifficulty(float flySpeed,float spawnInterval2)
    {
        foreach(Button btn in diffBtns)
        {
            btn.gameObject.SetActive(false);
        }
        title.gameObject.SetActive(false);
        spawnInterval=spawnInterval2;
        StartCoroutine(SpawnObjects(flySpeed));
        
    }
    public float GetSpeed()
    {
        return levelSpeed;
    }
}
