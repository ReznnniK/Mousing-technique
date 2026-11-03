using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    public float speedMax=15    f;
    public float speedMin=5f;
    public float torqueMax=25f;
    public float torqueMin=5f;
    float leftBorder = -5f;
    float rightBorder = 5f;
    float bottomPos=0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {
        transform.position = RandomPos();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), ForceMode.Impulse);
    }

    private Vector3 RandomTorque()
    {
        return Vector3.up * Random.Range(-0.5f, 0.5f) * Random.Range(torqueMin, torqueMax);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(speedMin, speedMax);
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(leftBorder, rightBorder), bottomPos, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
