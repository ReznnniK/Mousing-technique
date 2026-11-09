using UnityEngine;
using UnityEngine.UI;

public class DifficultiesBtns : MonoBehaviour
{
    public float speed = 10f;
    public float spawnInterval = 1f;
    private Button btn;
    private GameManager gm;

    void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetDifficulty);
        gm = FindAnyObjectByType<GameManager>();
    }

    public void SetDifficulty()
    {
        Debug.Log($"{gameObject.name} was clicked");
        gm.StartSpawnWithDifficulty(speed,spawnInterval);
    }
}
