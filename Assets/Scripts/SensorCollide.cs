using UnityEngine;

public class SensorCollide : MonoBehaviour
{
    GameManager gm;

    void Awake()
    {
        gm = FindAnyObjectByType<GameManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Good")) gm.GameOver();

        Destroy(other.gameObject);
    }
}
